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
                // source={require('../../assets/images/fundoPerfil.png')}
                style={StyleSheet.absoluteFillObject}
                style={styles.fundoMedico}
            >


                <View style={styles.container}>
                    <TouchableOpacity
                        onPress={this.buscarConsulta}
                    >
                        <Image
                            source={require('../../assets/images/logoLogin.png')}
                            style={styles.logoSp}
                        />
                    </TouchableOpacity>


                    <View style={styles.containerFlatList}>
                        <FlatList
                            contentContainerStyle={styles.mainBodyContent}
                            data={this.state.listaConsultas}
                            keyExtractor={item => item.idConsulta}
                            renderItem={this.renderItem}
                        />
                    </View>
                </View>

            </ImageBackground>
        )
    }

    renderItem = ({ item }) => (
        <View style={styles.teste}>
            <View style={styles.card}>
                <View style={styles.tituloCardWrapper}>
                    <Text>Consultas</Text>
                </View>
                <View style={styles.textoCardWrapper}>
                    <View style={styles.container_dados}>
                        <Text style={styles.tituloTexto}>Paciente</Text>
                        <Text style={styles.dados}>{item.idPacienteNavigation.idUsuarioNavigation.nome}</Text>
                    </View>
                    <View style={styles.container_dados}>
                        <Text style={styles.tituloTexto}>Medico</Text>
                        <Text style={styles.dados}>{item.idMedicoNavigation.idUsuarioNavigation.nome}</Text>
                    </View>
                    <View style={styles.container_dados}>
                        <Text style={styles.tituloTexto}>Situação</Text>
                        <Text style={styles.dados}>{item.idSituacaoNavigation.descricao}</Text>
                    </View>
                    <View style={styles.container_dados}>
                        <Text style={styles.tituloTexto}>Data da Consulta</Text>
                        <Text style={styles.dados}>{moment(item.dataConsulta).format('L')}</Text>
                    </View>
                    <View style={styles.container_dados}>
                        <Text style={styles.tituloTexto}>Descrição</Text>
                        <Text style={styles.dados}>{item.descricao}</Text>
                    </View>
                </View>
            </View>
        </View>
    )

};

// const styles = StyleSheet.create({
//     container: {
//         flex: 1,
//         alignItems: 'center'
//     },

// logoProjeto: {
//     marginTop: 70,
//     width:250,
//     height: 33,
// },

//     containerFlatList: {
//         flex: 1,
//         alignItems: 'center',
//         justifyContent: 'center',
//         marginTop: 20
//     },

//     container_consultas: {
//         width: 300,
//         height: 144,
//         marginTop: 25,
//         flexDirection: 'row',
//         justifyContent: 'center',
//     },

//     container_consulta: {
//         // backgroundColor: '#5049A9',
//         width: '100%',
//         height: 144,
//         borderRadius: 6,
//         alignItems: 'center',
//         justifyContent: 'center'
//     },

// container_dados: {
//     flexDirection: 'row',
//     justifyContent: 'center',
//     width: '90%',
//     height: 20,
// },

//     titulos: {
//         fontSize: 12,
//         fontWeight: 'bold',
//         color: '#fff',
//     },

// dados: {
//     fontSize: 12,
//     color: '#fff',
// },

//     descricao: {
//         // backgroundColor: '#ff0000',
//         alignItems: 'center',
//         width: '90%',
//         height: 50,
//         fontSize: 12,
//         fontWeight: 'light',
//         color: '#fff',
//     },


//     mainBodyContent: {
//         flex: 1,
//         justifyContent: 'space-around',
//     },

//     card: {
//         // alignItems: 'center',
//         width: '85%',
//         marginBottom: 30
//     },

//     tituloCard: {
//         color: 'black',
//         fontSize: 20,
//         fontWeight: '600'
//     },

//     tituloCardWrapper: {
//         backgroundColor: '#9081A6',
//         height: 33,
//         justifyContent: 'center',
//         alignItems: 'center',
//     },

// textoCardWrapper: {
//     backgroundColor: '#fff',
//     borderBottomLeftRadius: 10,
//     borderBottomRightRadius: 10,
//     padding: 20,
// },


//     tituloTexto: {
//         fontWeight: '800',
//     }

// })

const styles = StyleSheet.create({
    container: {
        flex: 1,
        alignItems: 'center'
    },

    fundoMedico: {
        backgroundColor: '#3D8DF2',
        flex: 1,
    },

    container_dados: {
        flexDirection: 'row',
        justifyContent: 'space-around',
        width: '90%',
        height: 25,
    },

    textoCardWrapper: {
        backgroundColor: '#fff',
        borderBottomLeftRadius: 10,
        borderBottomRightRadius: 10,
        padding: 20,
    },

    dados: {
        fontSize: 15,
        color: 'black',
    },

    logoSp: {
        marginTop: 70,
        width: 250,
        height: 33,
    },

    retangulo: {
        width: 300,
        height: 100,
        backgroundColor: 'red',
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
        // flex: 1,
        justifyContent: 'space-around',
    },

    card: {
        alignItems: 'center',
        width: '85%',
        marginBottom: 30
    },

    tituloCard: {
        color: 'black',
        fontSize: 20,
        fontWeight: '600'
    },

    tituloCardWrapper: {
        backgroundColor: '#45E1E6',
        height: 50,
        width: '104%',
        borderTopRightRadius: 5,
        borderTopLeftRadius: 5,
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