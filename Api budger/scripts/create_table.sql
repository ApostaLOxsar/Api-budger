-- DROP SCHEMA budgers;

CREATE SCHEMA budgers AUTHORIZATION postgres;

-- DROP SEQUENCE budgers.incom_categories_incomcategory_id_seq;

CREATE SEQUENCE budgers.incom_categories_incomcategory_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE budgers.incom_category_has_family_incom_category_has_family_id_seq;

CREATE SEQUENCE budgers.incom_category_has_family_incom_category_has_family_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE budgers.incoms_incom_id_seq;

CREATE SEQUENCE budgers.incoms_incom_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;-- budgers.incom_categories определение

-- Drop table

-- DROP TABLE budgers.incom_categories;

CREATE TABLE budgers.incom_categories (
	incom_category_id int8 DEFAULT nextval('budgers.incom_categories_incomcategory_id_seq'::regclass) NOT NULL,
	incom_category varchar NOT NULL,
	CONSTRAINT incom_categories_pk PRIMARY KEY (incom_category_id),
	CONSTRAINT incom_categories_unique UNIQUE (incom_category)
);


-- budgers.budger_categories определение

-- Drop table

-- DROP TABLE budgers.budger_categories;

CREATE TABLE budgers.budger_categories (
	budger_categoriy_id bigserial NOT NULL,
	budger_categoriy varchar NOT NULL,
	CONSTRAINT budger_categories_pk PRIMARY KEY (budger_categoriy_id),
	CONSTRAINT budger_categories_unique UNIQUE (budger_categoriy)
);


-- budgers.default_incom_category определение

-- Drop table

-- DROP TABLE budgers.default_incom_category;

CREATE TABLE budgers.default_incom_category (
	default_incom_category_id int8 DEFAULT nextval('budgers.default_incom_category_default_incom_category_seq'::regclass) NOT NULL,
	incom_category varchar NOT NULL,
	CONSTRAINT default_incom_category_pk PRIMARY KEY (default_incom_category_id),
	CONSTRAINT default_incom_category_unique UNIQUE (incom_category)
);


-- budgers.default_budger_category определение

-- Drop table

-- DROP TABLE budgers.default_budger_category;

CREATE TABLE budgers.default_budger_category (
	default_budger_category_id int8 NOT NULL,
	budger_category varchar NOT NULL,
	CONSTRAINT default_budger_category_pk PRIMARY KEY (default_budger_category_id),
	CONSTRAINT default_budger_category_unique UNIQUE (budger_category)
);


-- budgers.incom_category_has_family определение

-- Drop table

-- DROP TABLE budgers.incom_category_has_family;

CREATE TABLE budgers.incom_category_has_family (
	incom_category_has_family_id bigserial NOT NULL,
	family_id int8 NOT NULL,
	incom_id int8 NOT NULL,
	CONSTRAINT incom_category_has_family_pk PRIMARY KEY (incom_category_has_family_id)
);


-- budgers.incoms определение

-- Drop table

-- DROP TABLE budgers.incoms;

CREATE TABLE budgers.incoms (
	incom_id bigserial NOT NULL,
	incom int8 NOT NULL, -- доход
	"date" timetz DEFAULT now() NOT NULL,
	user_id int8 NOT NULL,
	"comment" varchar NULL,
	incom_category_id int8 NOT NULL,
	CONSTRAINT incoms_pk PRIMARY KEY (incom_id)
);

-- Column comments

COMMENT ON COLUMN budgers.incoms.incom IS 'доход';


-- budgers.budgers определение

-- Drop table

-- DROP TABLE budgers.budgers;

CREATE TABLE budgers.budgers (
	budger_id int8 DEFAULT nextval('budgers.budger_budger_id_seq'::regclass) NOT NULL,
	budger int8 NOT NULL,
	"date" timetz NOT NULL,
	user_id int8 NOT NULL,
	budger_categoriy_id int8 NOT NULL,
	CONSTRAINT budger_pk PRIMARY KEY (budger_id)
);


-- budgers.budger_category_has_family определение

-- Drop table

-- DROP TABLE budgers.budger_category_has_family;

CREATE TABLE budgers.budger_category_has_family (
	budger_category_has_family_id bigserial NOT NULL,
	family_id int8 NOT NULL,
	budger_id int8 NOT NULL,
	CONSTRAINT budger_category_has_family_pk PRIMARY KEY (budger_category_has_family_id)
);


-- budgers.incom_category_has_family внешние включи

ALTER TABLE budgers.incom_category_has_family ADD CONSTRAINT family_id FOREIGN KEY (family_id) REFERENCES clients.families(family_id);
ALTER TABLE budgers.incom_category_has_family ADD CONSTRAINT incom_id FOREIGN KEY (incom_id) REFERENCES budgers.incoms(incom_id);


-- budgers.incoms внешние включи

ALTER TABLE budgers.incoms ADD CONSTRAINT incom_category_id FOREIGN KEY (incom_category_id) REFERENCES budgers.incom_categories(incom_category_id);
ALTER TABLE budgers.incoms ADD CONSTRAINT user_id FOREIGN KEY (user_id) REFERENCES clients.users(user_id);


-- budgers.budgers внешние включи

ALTER TABLE budgers.budgers ADD CONSTRAINT budger_categoriy_id FOREIGN KEY (budger_categoriy_id) REFERENCES budgers.budger_categories(budger_categoriy_id);
ALTER TABLE budgers.budgers ADD CONSTRAINT user_id FOREIGN KEY (user_id) REFERENCES clients.users(user_id);


-- budgers.budger_category_has_family внешние включи

ALTER TABLE budgers.budger_category_has_family ADD CONSTRAINT budger_id FOREIGN KEY (budger_id) REFERENCES budgers.budgers(budger_id);
ALTER TABLE budgers.budger_category_has_family ADD CONSTRAINT family_id FOREIGN KEY (family_id) REFERENCES clients.families(family_id);

-- DROP SCHEMA clients;

CREATE SCHEMA clients AUTHORIZATION postgres;

-- DROP SEQUENCE clients.families_id_seq;

CREATE SEQUENCE clients.families_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE clients.role_id_seq;

CREATE SEQUENCE clients.role_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE clients.users_id_seq;

CREATE SEQUENCE clients.users_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;-- clients.families определение

-- Drop table

-- DROP TABLE clients.families;

CREATE TABLE clients.families (
	family_id int8 DEFAULT nextval('clients.families_id_seq'::regclass) NOT NULL,
	famili varchar NULL,
	CONSTRAINT familes_pk PRIMARY KEY (family_id)
);


-- clients.roles определение

-- Drop table

-- DROP TABLE clients.roles;

CREATE TABLE clients.roles (
	role_id int8 DEFAULT nextval('clients.role_id_seq'::regclass) NOT NULL,
	"role" varchar NOT NULL,
	role_rus varchar NOT NULL,
	CONSTRAINT role_pk PRIMARY KEY (role_id)
);
CREATE UNIQUE INDEX role_role_idx ON clients.roles USING btree (role, role_rus);


-- clients.users определение

-- Drop table

-- DROP TABLE clients.users;

CREATE TABLE clients.users (
	user_id int8 DEFAULT nextval('clients.users_id_seq'::regclass) NOT NULL,
	telegram_id int8 NOT NULL,
	role_id int8 NOT NULL,
	family_id int8 NOT NULL,
	CONSTRAINT users_pk PRIMARY KEY (user_id),
	CONSTRAINT users_unique UNIQUE (telegram_id),
	CONSTRAINT family_id FOREIGN KEY (family_id) REFERENCES clients.families(family_id),
	CONSTRAINT role_id FOREIGN KEY (role_id) REFERENCES clients.roles(role_id)
);