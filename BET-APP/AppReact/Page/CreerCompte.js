import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

export default function CreerCompte() {
    return (
        <View style={styles.container}>
            <Text style={styles.title}>Créer un compte</Text>
            {/* Ajoute ici les champs et boutons pour la création de compte */}
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#0C134F',
    },
    title: {
        color: '#FFFFFF',
        fontSize: 24,
        fontWeight: 'bold',
    },
});
