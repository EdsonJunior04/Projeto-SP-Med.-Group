import axios from "axios";
import { useState, useEffect } from 'react';
import { Link } from "react-router-dom";

import '../../Assets/CSS/paciente.css';

import logo from '../../Assets/img/Sp Medical Grouplogo.svg';

export default function Pacientes() {
    const [listaMinhasConsultas, setMinhasConsultas] = useState([]);


    function buscarMinhasConsultas() {
        axios('http://192.168.0.26:5000/api/Consultas/Lista/Minhas', {
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
        <div>

            <header>
                <div className="container_header_paciente">
                    <Link to="/">
                        <img
                            src={logo}
                            className="icone_paciente"
                            alt="logo da Sp Medical Group"
                        />{' '}
                    </Link>

                    <div>
                        <p>Paciente</p>

                    </div>

                </div>
            </header>

            <main className="afastar_list_paciente ">
                {/* Lista de tipos de consulta */}
                <section className="lista_paciente grid">
                    <h2>Minhas Consultas</h2>
                    <table>
                        <thead >
                            <tr>
                                <th>#</th>
                                <th>Situação</th>
                                <th>Paciente</th>
                                <th>Médico</th>
                                <th>Descrição</th>
                                <th>Data</th>
                            </tr>
                        </thead>
                        <tbody >
                            {
                                listaMinhasConsultas.map((consulta) => {
                                    return (
                                        <tr key={consulta.idConsulta} >
                                            <td>{consulta.idConsulta}</td>
                                            <td>{consulta.idSituacao}</td>
                                            <td>{consulta.idPacienteNavigation.idUsuarioNavigation.nome}</td>
                                            <td>{consulta.idMedicoNavigation.idUsuarioNavigation.nome}</td>
                                            <td>{consulta.descricao}</td>
                                            <td>{Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric', month: 'short', day: 'numeric',
                                                hour: 'numeric', minute: 'numeric', hour12: false
                                            }).format(new Date(consulta.dataConsulta))}</td>
                                        </tr>
                                    )
                                })
                            }
                        </tbody>
                    </table>
                </section>
            </main>
            <footer className="espaco">
                <div className="container_footer">
                    <div className="center_footer">
                        <Link to="/">
                            <img
                                src={logo}
                                className="icone_consulta_footer"
                                alt="logo da Sp Medical Group"
                            />{' '}
                        </Link>
                        <span className="span_footer">Feito por Senai de Informática</span>
                    </div>
                </div>
            </footer>
        </div>

    )
}