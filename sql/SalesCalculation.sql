
select sum(SaleSummary.subtotal) FROM 
(
select Sales.barcode, COALESCE(InventoryItems.item_length,0) * COALESCE(SaleItems.sell_price,0) AS subtotal from SaleItems
left outer join Sales ON Sales.id = SaleItems.sale_id
left outer join InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
where sale_id in (SELECT id FROM Sales where barcode > 72)
) SaleSummary


--(SELECT InventoryItems.inventory_id AS inventory_id,
--		COUNT(InventoryItems.item_length) AS qty,
--		SUM(InventoryItems.item_length) AS item_length,
--		SUM(InventoryItems.item_length * (sell_price + adjustment)) AS subtotal
--FROM (SELECT * FROM SaleItems WHERE SaleItems.sale_id = @sale_id) FilteredSaleItems
--	LEFT OUTER JOIN InventoryItems ON InventoryItems.id = FilteredSaleItems.inventory_item_id
--GROUP BY InventoryItems.inventory_id 
--) CalculatedSaleItems ON CalculatedSaleItems.inventory_id = Inventory.id




