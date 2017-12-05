CREATE TABLE BUYER (
	[ID] INT IDENTITY (1,1),
	[NAME] VARCHAR (255) NOT NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE SELLER (
	[ID] INT IDENTITY (1,1),
	[NAME] VARCHAR (255) NOT NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE ITEM (
	[ID] INT IDENTITY (1,1),
	[NAME] VARCHAR (255) NOT NULL,
	[DECRIPTION] VARCHAR (8000),
	[SELLER] INT FOREIGN KEY REFERENCES SELLER(ID) NOT NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE BID (
	[ID] INT IDENTITY (1,1),
	[ITEM] INT FOREIGN KEY REFERENCES ITEM(ID) NOT NULL,
	[BUYER] INT FOREIGN KEY REFERENCES BUYER(ID) NOT NULL,
	[PRICE] INT NOT NULL,
	[TIME] DATE NOT NULL,
	PRIMARY KEY (ID)
);

INSERT INTO BUYER VALUES
('Jane Stone'),
('Tom McMasters'),
('Otto Vanderwall');

INSERT INTO SELLER VALUES
('Gayle Hardy'),
('Lyle Banks'),
('Pearl Greene');

INSERT INTO ITEM VALUES
('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 3),
('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927', 1),
('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 2);

INSERT INTO BID VALUES
(1, 3, 250000,'12/04/2017 09:04:22'),
(3, 1, 95000 ,'12/04/2017 08:44:03');