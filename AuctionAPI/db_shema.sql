create table if not exists auctions
(
    id     uuid      not null
    constraint auctions_pk
    primary key,
    title  varchar   not null,
    start  timestamp not null,
    finish timestamp not null
);

create table if not exists lots
(
    id          uuid           not null
    constraint lots_pk
    primary key,
    auction_id  uuid           not null
    constraint lots_auctions_id_fk
    references auctions,
    title       varchar        not null,
    description varchar        not null,
    start_price numeric(18, 2) not null
    );

create table if not exists users
(
    id    uuid    not null
    constraint users_pk
    primary key,
    name  varchar not null,
    email varchar not null
);

create table if not exists bids
(
    id         uuid           not null
    constraint bids_pk
    primary key,
    user_id    uuid           not null
    constraint bids_users_id_fk
    references users,
    lot_id     uuid           not null
    constraint bids_lots_id_fk
    references lots,
    price      numeric(18, 2) not null,
    created_at timestamp      not null
);

