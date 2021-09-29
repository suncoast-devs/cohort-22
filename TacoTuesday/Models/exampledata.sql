-- Ensure we truncate the table and restart the identity so our Id column starts at 1 each time
TRUNCATE TABLE "Restaurants", "Reviews", "Users" RESTART IDENTITY;

-- Ensure we have a user to associate to the reviews below
INSERT INTO "Users" ("FullName", "Email", "HashedPassword") VALUES ('Sarah', 'sarah@suncoast.io', 'xxxxx');
INSERT INTO "Users" ("FullName", "Email", "HashedPassword") VALUES ('Mary', 'mary@suncoast.io', 'xxxxx');

INSERT INTO "Restaurants" ("Name", "Description", "Address", "Telephone", "Latitude", "Longitude", "UserId") VALUES ('Thoughtbeat', 'Inverse zero administration benchmark', '07 Meadow Vale Drive', '314-651-9791', 27.7970127, -82.6403897, 1);
INSERT INTO "Restaurants" ("Name", "Description", "Address", "Telephone", "Latitude", "Longitude", "UserId") VALUES ('Dabtype', 'Organized stable firmware', '7 Miller Park', '523-760-6681', 27.7970543, -82.6557106, 2);
INSERT INTO "Restaurants" ("Name", "Description", "Address", "Telephone", "Latitude", "Longitude", "UserId") VALUES ('Topdrive', 'Object-based interactive application', '65 Eliot Lane', '650-993-7074', 27.7833108, -82.7159637, 1);
INSERT INTO "Restaurants" ("Name", "Description", "Address", "Telephone", "Latitude", "Longitude", "UserId") VALUES ('Avaveo', 'Persistent zero defect process improvement', '2 Clarendon Junction', '715-663-5265', 27.7717197, -82.6522627, 2);

INSERT INTO "Reviews" ("RestaurantId", "CreatedAt", "Summary", "Body", "Stars", "UserId") VALUES (1, '2020-01-01 14:23:55', 'Yummy Food', 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Minima modi impedit quisquam sit, saepe enim placeat a vero voluptas asperiores atque laudantium in, nobis sunt blanditiis dignissimos. Deleniti, esse optio!', 3, 1);
INSERT INTO "Reviews" ("RestaurantId", "CreatedAt", "Summary", "Body", "Stars", "UserId") VALUES (1, '2020-01-01 18:23:55', 'Mmmmm, good', 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Minima modi impedit quisquam sit, saepe enim placeat a vero voluptas asperiores atque laudantium in, nobis sunt blanditiis dignissimos. Deleniti, esse optio!', 4, 1);