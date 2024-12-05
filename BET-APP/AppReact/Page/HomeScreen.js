import React from 'react';
import { StyleSheet, Text, View, TextInput, TouchableOpacity } from 'react-native';

export default function HomeScreen({ navigation }) {
    const handleSignUp = () => {
        navigation.navigate('CreerCompte'); // Redirection vers la page Créer un compte
    };

    return (
        <View style={styles.container}>
            {/* Header */}
            <View style={styles.header}>
                <Text style={styles.headerText}>CESIZI</Text>
            </View>

            {/* Login Section */}
            <View style={styles.content}>
                <Text style={styles.loginTitle}>Se connecter</Text>

                <View style={styles.inputContainer}>
                    <TextInput
                        style={styles.input}
                        placeholder="Identifiant :"
                        placeholderTextColor="#B3C8CF"
                    />
                    <TextInput
                        style={styles.input}
                        placeholder="Mot de passe :"
                        placeholderTextColor="#B3C8CF"
                        secureTextEntry
                    />
                </View>

                <TouchableOpacity style={styles.signUpLink} onPress={handleSignUp}>
                    <Text style={styles.signUpText}>
                        Vous n’avez pas de compte :{' '}
                        <Text style={styles.linkText}>Créer un compte</Text>
                    </Text>
                </TouchableOpacity>
            </View>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#0C134F',
    },
    header: {
        backgroundColor: '#5C469C',
        width: '100%',
        paddingVertical: 30,
        alignItems: 'center',
        borderBottomLeftRadius: 30,
        borderBottomRightRadius: 30,
    },
    headerText: {
        color: '#FFFFFF',
        fontSize: 28,
        fontWeight: 'bold',
    },
    content: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        paddingHorizontal: 20,
    },
    loginTitle: {
        color: '#FFFFFF',
        fontSize: 20,
        marginBottom: 20,
        fontWeight: 'bold',
    },
    inputContainer: {
        width: '100%',
    },
    input: {
        backgroundColor: '#FFFFFF',
        color: '#0C134F',
        paddingHorizontal: 15,
        paddingVertical: 12,
        borderRadius: 25,
        marginVertical: 10,
        fontSize: 16,
        borderWidth: 1,
        borderColor: '#B3C8CF',
    },
    signUpLink: {
        marginTop: 20,
    },
    signUpText: {
        color: '#FFFFFF',
        fontSize: 14,
        textAlign: 'center',
    },
    linkText: {
        color: '#B3C8CF',
        fontWeight: 'bold',
        textDecorationLine: 'underline',
    },
});
