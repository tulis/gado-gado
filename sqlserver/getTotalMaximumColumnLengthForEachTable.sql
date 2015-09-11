-- Get the maximum total length of columns for each table

SELECT OBJECT_NAME (id) tableName
		 , COUNT (1)        nr_columns
		 , SUM (length)     maxrowlength
	FROM   syscolumns	
	GROUP BY OBJECT_NAME (id)
	ORDER BY OBJECT_NAME (id)