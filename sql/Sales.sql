
SELECT summarytable.sale_year_month as month, SUM(summarytable.sale_total) AS sale_total, SUM(summarytable.profit) AS profit
FROM (
select Sales.time_stamp,
	CAST(YEAR(Sales.time_stamp) AS VARCHAR(4)) + '-' + CAST(MONTH(Sales.time_stamp) AS VARCHAR(2)) AS sale_year_month,
	SaleItems.sell_price, SaleItems.adjustment,
	InventoryItems.item_length,
	(COALESCE(SaleItems.sell_price,0) + COALESCE(SaleItems.adjustment,0)) * COALESCE(InventoryItems.item_length,0) AS sale_total,
	COALESCE(Inventory.buy_price,0) AS buy_price,
	(COALESCE(SaleItems.sell_price,0) + COALESCE(SaleItems.adjustment,0) - COALESCE(Inventory.buy_price,0)) * COALESCE(InventoryItems.item_length,0) AS profit
from SaleItems 
	left outer join Sales ON Sales.id = SaleItems.sale_id
	left outer join InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
	LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
WHERE return_id IS NULL
--ORDER BY Sales.time_stamp ASC
) summarytable
GROUP BY summarytable.sale_year_month
ORDER BY summarytable.sale_year_month ASC
