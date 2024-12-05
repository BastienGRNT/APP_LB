import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import HomeScreen from './Page/HomeScreen'; // Remplace par le chemin correct
import CreerCompte from './Page/CreerCompte'; // Remplace par le chemin correct

const Stack = createStackNavigator();

export default function App() {
    return (
        <NavigationContainer>
            <Stack.Navigator initialRouteName="Home">
                <Stack.Screen
                    name="Home"
                    component={HomeScreen}
                    options={{ headerShown: false }} // Supprime la barre d'en-tête par défaut
                />
                <Stack.Screen
                    name="CreerCompte"
                    component={CreerCompte}
                    options={{ title: 'Créer un compte' }}
                />
            </Stack.Navigator>
        </NavigationContainer>
    );
}
