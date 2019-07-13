
SELECT SUM(COALESCE(inventory_summary.available_item_length,0) * inventory_summary.buy_price) as inventory_value

FROM (
			SELECT Inventory.id,Inventory.code,Inventory.buy_price,Inventory.active,Inventory.product_id,Inventory.product_width_id,
					Inventory.length_unit_id,Inventory.color_id,color_name,Inventory.notes,Inventory.receive_date,
					Products.name_store + ': ' + Products.name_vendor AS product_name_full,
					Products.name_vendor AS product_name_vendor,
					Products.name_store AS product_name_store,
					ProductPrices.tag_price AS tag_price,
					Grades.id AS grade_id,
					Grades.grade_name AS grade_name,
					ProductWidths.product_width_name AS product_width_name,
					LengthUnits.length_unit_name AS length_unit_name,
					COALESCE(items_count.qty,0) AS qty,
					COALESCE(items_count.item_length,0) AS item_length,
					COALESCE(solditems_count.qty,0) AS sold_qty,
					COALESCE(solditems_count.item_length,0) AS sold_item_length,
					COALESCE(items_count.qty,0) - COALESCE(solditems_count.qty,0) AS available_qty,
					COALESCE(items_count.item_length,0) - COALESCE(solditems_count.item_length,0) AS available_item_length
					 
			FROM (((((((Inventory 
				LEFT OUTER JOIN Products ON Inventory.product_id = Products.id
				) LEFT OUTER JOIN ProductPrices
					ON (ProductPrices.product_id = Inventory.product_id
						AND ProductPrices.grade_id = Inventory.grade_id
						AND ProductPrices.product_width_id = Inventory.product_width_id
						AND ProductPrices.length_unit_id = Inventory.length_unit_id)
				) LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
				) LEFT OUTER JOIN LengthUnits ON Inventory.length_unit_id = LengthUnits.id
				) LEFT OUTER JOIN ProductWidths ON Inventory.product_width_id = ProductWidths.id
				) LEFT OUTER JOIN Colors ON Inventory.color_id = Colors.id
				) LEFT OUTER JOIN (SELECT InventoryItems.inventory_id, 
										COUNT(InventoryItems.item_length) AS qty,
										SUM(InventoryItems.item_length) AS item_length 
								 FROM InventoryItems GROUP BY InventoryItems.inventory_id) items_count 
				ON Inventory.id = items_count.inventory_id
				) LEFT OUTER JOIN (SELECT sold_inventory_items.inventory_id, 
										COUNT(sold_inventory_items.item_length) AS qty,
										SUM(sold_inventory_items.item_length) AS item_length 
								 FROM SaleItems
									 LEFT OUTER JOIN InventoryItems sold_inventory_items ON sold_inventory_items.id = SaleItems.inventory_item_id
								 WHERE SaleItems.return_id IS null
								 GROUP BY sold_inventory_items.inventory_id) solditems_count 
				ON Inventory.id = solditems_count.inventory_id
) inventory_summary
