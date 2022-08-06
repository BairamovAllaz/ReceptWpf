CREATE TABLE Food(
     food_id INTEGER PRIMARY KEY AUTOINCREMENT,
     preparation_time TEXT NOT NULL,
     difficulty_food TEXT NOT NULL,
     created_time TEXT NOT NULL,
     food_photo TEXT NOT NULL,
     food_title TEXT NOT NULL,
     ingredients TEXT NOT NULL,
     pretensions TEXT NOT NULL,
     created_by TEXT NOT NULL
);