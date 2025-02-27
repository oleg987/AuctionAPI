create table auctions
(
    id     uuid      not null
        constraint auctions_pk
            primary key,
    title  varchar   not null,
    start  timestamp not null,
    finish timestamp not null
);