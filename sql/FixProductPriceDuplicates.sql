DELETE ProductPrices WHERE id IN ('','','','','','','','','','','','','','','','','','','','','','','','','')


	SELECT ProductPrices.id, product_store_name_id,product_width_id,length_unit_id,
	tag_price,ProductPrices.notes,
		ProductStoreNames.name AS product_name_store,
		ProductWidths.product_width_name AS width_name,
		LengthUnits.length_unit_name AS length_unit_name, 
		Grades.grade_name AS grade_name 
	FROM (((ProductPrices 
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = ProductPrices.product_store_name_id
		) LEFT OUTER JOIN ProductWidths ON ProductWidths.id = ProductPrices.product_width_id
		) LEFT OUTER JOIN LengthUnits ON LengthUnits.id = ProductPrices.length_unit_id
		) LEFT OUTER JOIN Grades ON Grades.id = ProductPrices.grade_id
	ORDER BY ProductStoreNames.name ASC, width_name ASC, grade_name ASC, LengthUnits.length_unit_name ASC

