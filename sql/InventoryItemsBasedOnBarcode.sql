            
                SELECT barcode AS Barcode,
                        Inventory.code AS CODE,
                        item_length AS Qty, 
                        ProductWidths.product_width_name AS 'lebar (cm)', 
                        Products.name_store AS Product,
                        Grades.grade_name AS Grade,
                        Colors.color_name AS Warna,
						ActivityLog.time_stamp AS timestamps, 
						ActivityLog.description AS activiylogs
	            FROM (((((((InventoryItems 
		            LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
		            ) LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		            ) LEFT OUTER JOIN ProductWidths ON ProductWidths.id = Inventory.product_width_id
		            ) LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		            ) LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		            ) LEFT OUTER JOIN Colors ON Colors.id = Inventory.color_id
		            ) LEFT OUTER JOIN ActivityLog ON ActivityLog.associated_id = InventoryItems.id
		            ) LEFT OUTER JOIN ProductPrices
			            ON (ProductPrices.product_id = Inventory.product_id
				            AND ProductPrices.grade_id = Inventory.grade_id
				            AND ProductPrices.product_width_id = Inventory.product_width_id
				            AND ProductPrices.length_unit_id = Inventory.length_unit_id)

						WHERE InventoryItems.Barcode = '005A0'