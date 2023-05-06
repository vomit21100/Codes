use shopmee;
show variables like '%secure%';

LOAD DATA INFILE '4.csv' into table product
CHARACTER SET UTF8 FIELDS TERMINATED BY ','
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
(name, price, Description, quantity, Sold_Out, CategoryID, imgPath, sellerID);
