create table Friendship
(
    user_1  varchar(50) not null
        references user_login (identifiant)
            on delete cascade,
    user_2  varchar(50) not null
        references user_login (identifiant)
            on delete cascade,
    statut        varchar(20) default 'en_attente'::character varying
        constraint friend_statut_check
            check ((statut)::text = ANY
                   ((ARRAY ['en_attente'::character varying, 'accepté'::character varying, 'bloqué'::character varying])::text[])),
    date_friendship timestamp   default CURRENT_TIMESTAMP,
    primary key (user_1, user_2),
    constraint friend_check
        check ((user_1)::text <> (user_2)::text)
    );