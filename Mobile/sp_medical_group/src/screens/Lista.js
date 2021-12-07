import React, { Compon, Component } from 'react';
import { FlatList, Image, ImageBackground, StyleSheet, Text, TouchableOpacity, View } from 'react-native';
import moment from 'moment';
import api from '../services/api'

import AsyncStorage from '@react-native-async-storage/async-storage';


export default class ListaConsulta extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: [],
        };
    }



    buscarConsulta = async () => {
        try {
            const token = await AsyncStorage.getItem('userToken');

            const resposta = await api.get('/Consultas/Lista/Minhas', {
                headers: {
                    Authorization: 'Bearer ' + token
                }
            })
            if (resposta.status == 200) {
                const dados = resposta.data.listaConsulta
                this.setState({ listaConsultas: dados });
            }
        }

        catch (error) {
            console.warn(error)
        }


    };


    componentDidMount() {
        this.buscarConsulta();
    };


    render() {
        return (

            <ImageBackground
                source={require('../../assets/images/fundoPerfil.png')}
                style={StyleSheet.absoluteFillObject}
            >


                <View style={styles.container}>
                    <TouchableOpacity
                        onPress={this.buscarConsulta}
                    >
                        <Image
                            source={require('../../assets/images/logoLogin.png')}
                            style={styles.logoProjeto}
                        />
                    </TouchableOpacity>


                    {/* <View style={styles.containerFlatList}> */}
                        <FlatList
                            contentContainerStyle={styles.mainBodyContent}
                            data={this.state.listaConsultas}
                            keyExtractor={item => item.idConsulta}
                            renderItem={this.renderItem}
                        />
                    {/* </View> */}
                </View>

            </ImageBackground>
        )
    }

    renderItem = ({ item }) => (
        <View style={styles.container_consultas}>
        <View style={styles.container_consulta}>
            <View style={styles.container_dados}>
                <Text style={styles.titulos}>Paciente</Text>
                <Text style={styles.dados}>{item.idPacienteNavigation.idUsuarioNavigation.nome}</Text>
            </View>
            <View style={styles.container_dados}>
                <Text style={styles.titulos}>Situação</Text>
                <Text style={styles.dados}>{item.idSituacaoNavigation.descricao}</Text>
            </View>
            <View style={styles.container_dados}>
                <Text style={styles.titulos}>Data da Consulta</Text>
                <Text style={styles.dados}>{moment(item.dataConsulta).format('L')}</Text>
            </View>
            <View style={styles.container_dados}>
                <Text style={styles.titulos}>Descrição</Text>
            </View>
            <Text style={styles.descricao}>{item.descricao}</Text>
        </View>
    </View>
    )

};

const styles = StyleSheet.create({
    container: {
        flex: 1,
        alignItems: 'center'
    },

    logoProjeto: {
        marginTop: 70,
        width:250,
        height: 33,
    },

    containerFlatList: {
        flex: 1,
        alignItems: 'center',
        justifyContent: 'center',
        marginTop: 20
    },

    teste: {
        alignItems: 'center'
    },

    mainBodyContent: {
        flex: 1,
        justifyContent: 'space-around',
    },

    card: {
        // alignItems: 'center',
        width: '85%',
        marginBottom: 30
    },

    tituloCard: {
        color: 'black',
        fontSize: 20,
        fontWeight: '600'
    },

    tituloCardWrapper: {
        backgroundColor: '#9081A6',
        height: 33,
        justifyContent: 'center',
        alignItems: 'center',
    },

    textoCardWrapper: {
        backgroundColor: '#fff',
        borderBottomLeftRadius: 10,
        borderBottomRightRadius: 10,
        padding: 20,
    },


    tituloTexto: {
        fontWeight: '800',
    }

})