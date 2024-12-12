SELECT COUNT(*) FROM user_login WHERE identifiant = @Identifiant;

SELECT COUNT(*) FROM user_login WHERE adresse_mail = @AdresseMail;

INSERT INTO user_login (identifiant, adresse_mail, mot_de_passe) VALUES (@Identifiant, @AdresseMail, @MotDePasse);
