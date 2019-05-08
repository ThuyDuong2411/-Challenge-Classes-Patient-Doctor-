create table Faculty(
id_fac int primary key not null,
name_fac nvarchar(max) not null
)
create table Doctor(
id_doc int primary key not null,
name_doc nvarchar(max) not null,
id_fac int FOREIGN KEY REFERENCES Faculty(id_fac)
)
create table Patient(
id_pat int primary key not null,
name_pat nvarchar(max) not null,
id_doc int FOREIGN KEY REFERENCES Doctor(id_doc)
)
