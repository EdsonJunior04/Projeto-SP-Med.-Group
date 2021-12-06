import React, { Compon, Component } from 'react';
import { FlatList, Image, ImageBackground, StatusBar, StyleSheet, Text, View } from 'react-native';

import Medico from './Medico';

import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const bottomTab = createBottomTabNavigator();






export default class Main extends Component {
  render() {
    return (
      <View style={styles.main}>
        <StatusBar
          hidden={false}
          backgroundColor={'#6A518C'}
           />

        <bottomTab.Navigator
          initialRouteName='Lista'

          screenOptions={({ route }) => ({
            tabBarIcon: () => {
              if (route.name === 'Lista') {
                return (
                  <Image
                  style={styles.tabBarIconProjeto}
                  />
                )
              }
              if (route.name === 'Lista') {
                return (
                  <Image
                  style={styles.tabBarIcon}
                  />
                )
              }
            },

            headerShown: false,
            tabBarShowLabel: false,
            tabBarInactiveBackgroundColor: '#C4C4C4',
            tabBarStyle: { height: 50 }
          }
          )}
        >
          {/* <bottomTab.Screen name='Projetos' component={Projetos} /> */}
          <bottomTab.Screen name='Medico' component={Medico} />
        </bottomTab.Navigator>
      </View>
    )
  }
};

const styles = StyleSheet.create({
  // conteúdo da main
  main: {
    flex: 1,
    // backgroundColor: '#F1F1F1'
  },
   // estilo dos ícones da tabBar
   tabBarIcon: {
    width: 60,
    height: 40,
    tintColor: '#361264'
  },

  tabBarIconProjeto: {
    width: 40,
    height: 40,
    tintColor: '#361264'
  }
});