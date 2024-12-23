CREATE TABLE "Player" (
                          "ID" SERIAL PRIMARY KEY,
                          "Name" VARCHAR(100) NOT NULL
);

CREATE TABLE "Game" (
                        "ID" SERIAL PRIMARY KEY,
                        "Player1_ID" INT NOT NULL,
                        "Player2_ID" INT NOT NULL,
                        "Player1_Score" INT NOT NULL,
                        "Player2_Score" INT NOT NULL,
                        CHECK ("Player1_ID" <> "Player2_ID"), -- Ensures players are different
                        CHECK ("Player1_Score" = -"Player2_Score"), -- Ensures score symmetry
                        UNIQUE ("Player1_ID", "Player2_ID"), -- Prevents duplicate pairings
                        FOREIGN KEY ("Player1_ID") REFERENCES "Player"("ID"), -- Enforces foreign key
                        FOREIGN KEY ("Player2_ID") REFERENCES "Player"("ID"), -- Enforces foreign key
                        "LastModifyDate" TIMESTAMP DEFAULT NOW() -- Add the missing comma here
);

CREATE OR REPLACE FUNCTION update_last_modified()
RETURNS TRIGGER AS $$
BEGIN
    NEW."LastModifyDate" = NOW();
RETURN NEW;
END;
$$ LANGUAGE plpgsql; -- Specify the language for the function

CREATE TRIGGER set_last_modified
    BEFORE UPDATE ON "Game" -- Table name should match casing
    FOR EACH ROW
    EXECUTE FUNCTION update_last_modified();
