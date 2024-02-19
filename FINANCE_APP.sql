
USE Finance ;
	CREATE TABLE Budget
	(
		Id INT NOT NULL IDENTITY(1,1)  PRIMARY KEY ,
		Name NVARCHAR(256) NOT NULL ,
		Description NVARCHAR(256) NOT NULL,
		Price FLOAT NOT NULL,
		Quanti	ty INT NOT NULL
	)
--DROP TABLE Budget
SELECT * FROM Budget ;
	
INSERT INTO Budget (Name ,Description ,Price , Quantity) VALUES('IPAD','NEW' , 99.5,2)
INSERT INTO Budget ( Name, Description, Price, Quantity) VALUES ( 'Smartphone', 'Latest model with advanced features', 699.99, 3);
INSERT INTO Budget (Name, Description, Price, Quantity) VALUES ('Desk Chair', 'Ergonomic office chair', 149.95, 1);

INSERT INTO Budget (Name, Description, Price, Quantity)
VALUES
  ('IPAD', 'NEW', 99.5, 2),
  ('Smartphone', 'Latest model with advanced features', 699.99, 3),
  ('Desk Chair', 'Ergonomic office chair', 149.95, 1),
  ('Laptop', 'High-performance laptop', 1299.99, 2),
  ('Coffee Maker', 'Automatic drip coffee maker', 49.95, 1),
  ('Headphones', 'Noise-canceling headphones', 199.99, 2),
  ('Bluetooth Speaker', 'Portable Bluetooth speaker', 79.99, 1),
  ('External Hard Drive', '1TB external hard drive', 79.95, 1),
  ('Desk Lamp', 'LED desk lamp', 29.99, 1),
  ('Mouse', 'Wireless computer mouse', 19.95, 1),
  ('Keyboard', 'Mechanical gaming keyboard', 89.99, 1),
  ('Monitor', '27-inch HD monitor', 249.99, 1),
  ('Backpack', 'Water-resistant backpack', 59.95, 1),
  ('Fitness Tracker', 'Smart fitness tracker', 129.99, 1),
  ('Sunglasses', 'Polarized sunglasses', 59.95, 1),
  ('Watch', 'Stylish wristwatch', 149.99, 1),
  ('Printer', 'All-in-one printer', 149.95, 1),
  ('Bookshelf', 'Wooden bookshelf', 99.99, 1),
  ('Coffee Table', 'Modern coffee table', 149.99, 1),
  ('Vacuum Cleaner', 'Bagless vacuum cleaner', 129.95, 1),
  -- Add 10 more items with similar syntax
  ('Item21', 'Description21', 79.99, 2),
  ('Item22', 'Description22', 39.95, 3),
  ('Item23', 'Description23', 149.99, 1),
  ('Item24', 'Description24', 19.95, 4),
  ('Item25', 'Description25', 129.99, 2),
  ('Item26', 'Description26', 99.95, 1),
  ('Item27', 'Description27', 199.99, 1),
  ('Item28', 'Description28', 49.95, 3),
  ('Item29', 'Description29', 29.99, 2),
  ('Item30', 'Description30', 79.95, 1);
