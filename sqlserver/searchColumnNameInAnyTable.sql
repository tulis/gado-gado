-- Search column name in any table

SELECT OBJECT_NAME (id) tableName, name
	FROM   syscolumns		
	WHERE name LIKE '%Defect%'
		OR OBJECT_NAME (id) LIKE '%defect%'
	ORDER BY OBJECT_NAME (id)