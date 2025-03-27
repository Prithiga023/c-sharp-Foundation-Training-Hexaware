-- Create the Artists table
CREATE TABLE Artists (
ArtistID INT PRIMARY KEY,
Name VARCHAR(255) NOT NULL,
Biography TEXT,
Nationality VARCHAR(100));

-- Create the Categories table
CREATE TABLE Categories (
CategoryID INT PRIMARY KEY,
Name VARCHAR(100) NOT NULL);
-- Create the Artworks table
CREATE TABLE Artworks (
ArtworkID INT PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
ArtistID INT,
CategoryID INT,
Year INT,
Description TEXT,
ImageURL VARCHAR(255),
FOREIGN KEY (ArtistID) REFERENCES Artists (ArtistID),
FOREIGN KEY (CategoryID) REFERENCES Categories (CategoryID));
-- Create the Exhibitions table
CREATE TABLE Exhibitions (
ExhibitionID INT PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
StartDate DATE,
EndDate DATE,
Description TEXT);
-- Create a table to associate artworks with exhibitions
CREATE TABLE ExhibitionArtworks (
ExhibitionID INT,
ArtworkID INT,
PRIMARY KEY (ExhibitionID, ArtworkID),
FOREIGN KEY (ExhibitionID) REFERENCES Exhibitions (ExhibitionID),
FOREIGN KEY (ArtworkID) REFERENCES Artworks (ArtworkID));

-- Insert sample data into the Artists table
INSERT INTO Artists (ArtistID, Name, Biography, Nationality) VALUES
(1, 'Pablo Picasso', 'Renowned Spanish painter and sculptor.', 'Spanish'),
(2, 'Vincent van Gogh', 'Dutch post-impressionist painter.', 'Dutch'),
(3, 'Leonardo da Vinci', 'Italian polymath of the Renaissance.', 'Italian');

-- Insert sample data into the Categories table
INSERT INTO Categories (CategoryID, Name) VALUES
(1, 'Painting'),
(2, 'Sculpture'),
(3, 'Photography');

-- Insert sample data into the Artworks table
INSERT INTO Artworks (ArtworkID, Title, ArtistID, CategoryID, Year, Description, ImageURL) VALUES
(1, 'Starry Night', 2, 1, 1889, 'A famous painting by Vincent van Gogh.', 'starry_night.jpg'),
(2, 'Mona Lisa', 3, 1, 1503, 'The iconic portrait by Leonardo da Vinci.', 'mona_lisa.jpg'),
(3, 'Guernica', 1, 1, 1937, 'Pablo Picasso''s powerful anti-war mural.', 'guernica.jpg');

-- Insert sample data into the Exhibitions table
INSERT INTO Exhibitions (ExhibitionID, Title, StartDate, EndDate, Description) VALUES
(1, 'Modern Art Masterpieces', '2023-01-01', '2023-03-01', 'A collection of modern art masterpieces.'),
(2, 'Renaissance Art', '2023-04-01', '2023-06-01', 'A showcase of Renaissance art treasures.');

-- Insert artworks into exhibitions
INSERT INTO ExhibitionArtworks (ExhibitionID, ArtworkID) VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 2);

--retrieve names of all artist with number of artworks they have in gallery in descending order
select a.name,count(art.artworkid) as total_artworks
from artists a
left join artworks art on a.artistid = art.ArtistID
group by a.name order by total_artworks desc;

--titles of artwork created from spanish and dutch  and order them by year in ascending order
select art.title from Artworks art
join Artists a on art.ArtistID = a.ArtistID
where a.Nationality in('spanish','dutch') order by art.year asc;

--names of all artists who have artwork in painting category and number of artworks in this
select a.name, count(art.artworkid) as total_paintings from Artists a
join Artworks art on  a.ArtistID = art.ArtistID
join Categories c on art.CategoryID = c.CategoryID
where c.Name = 'painting' group by a.Name

-- names of artworks from modern art masterpieces exhibition along with their artists and categories
select art.title, a.name as artist_name, c.name as category_name from artworks art  
join artists a on art.artistid = a.artistid  
join categories c on art.categoryid = c.categoryid  
join ExhibitionArtworks ea on art.artworkid = ea.artworkid  
join exhibitions e on ea.exhibitionid = e.exhibitionid  
where e.title = 'Modern Art Masterpieces';

insert into artworks (artworkid, title, artistid, categoryid, year, description, imageurl) 
values 
(101, 'The Weeping Woman', 1, 1, 1937, 'A masterpiece by Pablo Picasso.', 'weeping_woman.jpg'),
(102, 'Les Demoiselles d’Avignon', 1, 1, 1907, 'A famous painting by Picasso.', 'demoiselles.jpg'),
(103, 'Irises', 2, 1, 1889, 'A stunning artwork by Vincent van Gogh.', 'irises.jpg'),
(104, 'Sunflowers', 2, 1, 1888, 'One of Van Gogh’s iconic paintings.', 'sunflowers.jpg'),
(105, 'The Bedroom', 2, 1, 1888, 'Van Gogh’s painting of his bedroom.', 'bedroom.jpg'),
(106, 'Impression, Sunrise', 3, 1, 1872, 'A famous artwork by Claude Monet.', 'sunrise.jpg'),
(107, 'Woman with a Parasol', 3, 1, 1875, 'Another painting by Monet.', 'parasol.jpg'),
(108, 'Water Lilies', 3, 1, 1919, 'One of Monet’s water lily paintings.', 'water_lilies.jpg');



--artist having more than two artworks
select a.name, count(art.artworkid) as total_artworks from artists a  
join artworks art on a.artistid = art.artistid group by a.artistid, a.name having count(art.artworkid) > 2  
order by total_artworks desc;

--artworks that exhibited both in modern art masterpieces and renaissance art exhibition
select art.Title  from artworks art  
join ExhibitionArtworks ea1 on art.artworkid = ea1.artworkid  
join exhibitions ex1 on ea1.exhibitionid = ex1.exhibitionid  
join ExhibitionArtworks ea2 on art.artworkid = ea2.artworkid  
join exhibitions ex2 on ea2.exhibitionid = ex2.exhibitionid
where ex1.title = 'Modern Art Masterpieces' and ex2.title = 'Renaissance Art';

--total number of artworks in each catg
select c.name as category_name, count(a.artworkid) as total_artworks from Categories c
left join Artworks a on c.CategoryID = a.CategoryID group by c.Name
order by total_artworks desc;

--artist having more thanthree artwork
select a.name, count(art.artworkid) as total_artworks from Artists a
join artworks art on a.ArtistID = art.ArtistID group by a.ArtistID, a.Name having count(art.artworkid) > 3
order by total_artworks desc;

--artworks created by artists from specific nation
select art.title, a.name as artist_name, a.nationality from Artworks art 
join Artists a on art.ArtistID = a.ArtistID
where a.Nationality ='spanish' order by art.Title

--exhibition featuring artwork of both vincent van and leonardo
select e.title from Exhibitions e
join ExhibitionArtworks ea on e.ExhibitionID = ea.ExhibitionID
join Artworks a on ea.ArtworkID = a.ArtworkID
join Artists ar on a.ArtistID = ar.ArtistID where 
ar.name in ('vincent van gogh','leonardo da vinci')
group by e.Title having count(distinct ar.name)=2;

--artworks not been included in any exhib
select a.title from Artworks a 
left join ExhibitionArtworks ea on a.ArtworkID= ea.ArtworkID where
ea.ArtworkID is null;

insert into artworks (artworkid, title, artistid, categoryid, year, description, imageurl)  
values 
(10, 'Picasso Sculpture', 1, 2, 1955, 'A sculpture by Picasso', 'picasso_sculpture.jpg'),
(11, 'Picasso Photography', 1, 3, 1960, 'A photography piece by Picasso', 'picasso_photo.jpg');


--artist who have created artworks in all categ
select a.name from artists a 
join Artworks art on a.ArtistID = art.ArtistID
join Categories c on art.CategoryID = c.CategoryID group by
a.ArtistID, a.Name having count(distinct c.categoryid)=(select count(*) from Categories);
 
--total numb of artworks in each categ
select c.name as category_name,count(a.artworkid) as total_artworks from 
Categories c
left join Artworks a on c.CategoryID = a.CategoryID group by c.Name
order by total_artworks desc;

-- artists who have more than 2 artworks in the gallery.

--catgeories with avg year of artworks only for categories  with more than 1 artwork
select c.name as category_name, AVG(a.year) as average_year from 
Categories c
join Artworks a on c.CategoryID=a.CategoryID group by
c.Name having count(a.artworkid)>1 order
by average_year

--artworks exhibited in modern art exhib
select a.title from Artworks a
join ExhibitionArtworks ea on a.ArtworkID= ea.ArtworkID
join Exhibitions e on ea.ExhibitionID = e.ExhibitionID where
e.Title='modern art masterpieces'

--categ which have avg year of artwork greater than avg year oaf all artworks
select c.name as category_name from Categories c
join Artworks a on c.CategoryID= a.CategoryID
group by c.CategoryID,c.name having
avg(a.year) > (select avg(year) from Artworks);

--artworks that were not exhibites in any exhibition
select a.title from Artworks a 
left join ExhibitionArtworks ea on a.ArtworkID = ea.ArtworkID where
ea.ArtworkID is null;

--artists who have artworks in same category as monalisa
select distinct a.name from Artists a
join Artworks art on a.ArtistID= art.ArtistID
where art.CategoryID = (select CategoryID from Artworks where Title='mona lisa')

--names of artists and number ofartwork they have in gallery
select a.name, count(art.artworkid) as total_artworks from Artists a
left join Artworks art on a.ArtistID = art.ArtistID 
group by a.name order by
count(art.ArtworkID) desc

