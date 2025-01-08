DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_database WHERE datname = 'rivella') THEN
        CREATE DATABASE rivella;
END IF;
END
$$;
       
\c rivella

CREATE TABLE IF NOT EXISTS Albums (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    code UUID NOT NULL,
    qr_code BYTEA NOT NULL,
    revelation_date TIMESTAMP NOT NULL,
    date_created TIMESTAMP NOT NULL
);

CREATE TABLE IF NOT EXISTS Photos (
    id SERIAL PRIMARY KEY,
    url VARCHAR(200) NOT NULL,
    date_upload TIMESTAMP NOT NULL,
    description VARCHAR(200) NULL,
    album_id INT NOT NULL,
    CONSTRAINT fk_albumid_album_id FOREIGN KEY (album_id) REFERENCES Albums(Id) ON DELETE CASCADE
    );
