SELECT COUNT(*)
FROM friendship
WHERE user_1 = @user2 AND user_2 = @user1;

UPDATE friendship
SET statut = 'accepté'
WHERE user_1 = @user1 AND user_2 = @user2;

INSERT INTO friendship (user_1, user_2, statut, date_friendship)
VALUES (@user1, @user2, @statut, CURRENT_TIMESTAMP);
