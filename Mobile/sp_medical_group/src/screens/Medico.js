import React, { useState, useEffect } from "react";
import {  Text,View } from "react-native";
import api from "../services/api";

export default function Medico() {
    const [listaMinhasConsultas, setMinhasConsultas] = useState([])
    const [_data, setData] = useState(new Date())

    function buscarMinhasConsultas() {
        api.get('/Consultas/Lista/Minhas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    setMinhasConsultas(resposta.data.listaConsulta)
                }
            })
            .catch(erro => console.log(erro))
    }
    useEffect(buscarMinhasConsultas, [])

    return (
        <View>
           <Text>teste</Text>
        </View>
    )
    }