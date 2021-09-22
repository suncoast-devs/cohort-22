-- Ensure we truncate the table and restart the identity so our Id column starts at 1 each time
TRUNCATE TABLE "Restaurants", "Reviews" RESTART IDENTITY;

INSERT INTO "Restaurants" ("Name", "Description", "Address", "Telephone") VALUES ('Thoughtbeat', 'Inverse zero administration benchmark', '07 Meadow Vale Drive', '314-651-9791');
INSERT INTO "Restaurants" ("Name", "Description", "Address", "Telephone") VALUES ('Dabtype', 'Organized stable firmware', '7 Miller Park', '523-760-6681');
INSERT INTO "Restaurants" ("Name", "Description", "Address", "Telephone") VALUES ('Topdrive', 'Object-based interactive application', '65 Eliot Lane', '650-993-7074');
INSERT INTO "Restaurants" ("Name", "Description", "Address", "Telephone") VALUES ('Avaveo', 'Persistent zero defect process improvement', '2 Clarendon Junction', '715-663-5265');

INSERT INTO "Reviews" ("RestaurantId", "CreatedAt", "Summary", "Body", "Stars") VALUES (1, '2020-01-01 14:23:55', 'Yummy Food', 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Minima modi impedit quisquam sit, saepe enim placeat a vero voluptas asperiores atque laudantium in, nobis sunt blanditiis dignissimos. Deleniti, esse optio!', 3);
INSERT INTO "Reviews" ("RestaurantId", "CreatedAt", "Summary", "Body", "Stars") VALUES (1, '2020-01-01 18:23:55', 'Mmmmm, good', 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Minima modi impedit quisquam sit, saepe enim placeat a vero voluptas asperiores atque laudantium in, nobis sunt blanditiis dignissimos. Deleniti, esse optio!', 4);