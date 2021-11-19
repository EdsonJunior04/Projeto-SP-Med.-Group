import { useState, useEffect } from 'react';
import axios from "axios";
import { Link } from "react-router-dom";

import logo from '../../Assets/img/Sp Medical Grouplogo.svg';


import '../../Assets/CSS/Consultas.css';

export default function ConsultaAdm() {
    const [listaConsulta, setListaConsulta] = useState([]);
    const [listaMedico, setListaMedico] = useState([]);
    const [listaPaciente] = useState([]);
    const [idPaciente, setIdPaciente] = useState('');
    const [idMedico, setIdMedico] = useState('');
    const [dataConsulta, setDataConsulta] = useState('');
    const [isLoading, setIsLoading] = useState(false);

    function listarConsultas() {
        axios('http://localhost:5000/api/Consultas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsulta(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
    };

    useEffect(listarConsultas, []);

    function listarMedicos() {
        axios('http://localhost:5000/api/Medicos', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaMedico(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
    }

    useEffect(listarMedicos, []);

    // function listarPacientes() {
    //     axios('http://localhost:5000/api/Pacientes', {
    //         headers: {
    //             'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
    //         }
    //     })
    //         .then(resposta => {
    //             if (resposta.status === 200) {
    //                 setListaPaciente(resposta.data.lista)
    //                 console.log(listaPaciente)
    //             }
    //         })

    //         .catch(erro => console.log(erro))
    // }

    // useEffect(listarPacientes, []);

    function cadastrarConsulta(evento) {
        setIsLoading(true);

        evento.preventDefault()

        axios
            .post('http://localhost:5000/api/Consultas', {
                idPaciente: idPaciente,
                idMedico: idMedico,
                dataConsulta: dataConsulta
            }, {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
            .then((resposta) => {
                if (resposta.status === 201) {
                    console.log('Consulta cadastrada');
                    setIdMedico('');
                    setIdPaciente('');
                    setDataConsulta('');
                    listarConsultas();
                    setIsLoading(false);
                }
            })
            .catch(erro => console.log(erro), setIdMedico(''), setIdPaciente(''), setDataConsulta(''), setInterval(() => {
                setIsLoading(false)
            }, 5000));
    }
    return (
        //JSX
        <div>

            <header>
                <div className="container_header_consulta">
                    <Link to="/">
                        <img
                            src={logo}
                            className="icone_consulta"
                            alt="logo da Sp Medical Group"
                        />{' '}
                    </Link>

                    <div>
                        <Link to="/login" className="links_header"> Login </Link>
                        <Link to="/" className="links_header"> Home </Link>

                    </div>

                </div>
            </header>

            <main className="afastar_list_consulta ">
                {/* Lista de tipos de consulta */}
                <section className="lista_consulta grid">
                    <h2>Lista de Consultas</h2>
                    <table>
                        <thead >
                            <tr>
                                <th>#</th>
                                <th>Paciente</th>
                                <th>Médico</th>
                                <th>Descrição</th>
                                <th>Data</th>
                            </tr>
                        </thead>
                        <tbody >
                            {
                                listaConsulta.map((consulta) => {
                                    return (
                                        <tr key={consulta.idConsulta} >
                                            <td>{consulta.idConsulta}</td>
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


                {/* Cadastro de tipos de consulta */}
                <section className="cadastro_consulta grid">
                    <h2 className="letra_tam">Cadastro de Consultas</h2>
                    <div className="cadastro_ajuste_consulta">
                        <form onSubmit={cadastrarConsulta} >
                            <div>
                                <select
                                    className="input_consulta"
                                    name="paciente"
                                    id="paciente"
                                    value={idPaciente}
                                    onChange={(campo) => setIdPaciente(campo.target.value)}>
                                    <option value="0">Nome Paciente</option>
                                    {
                                        listaPaciente.map((paciente) => {
                                            return (
                                                <option key={paciente.idPaciente} value={paciente.idPaciente}>
                                                    {paciente.idUsuarioNavigation.nome}
                                                </option>
                                            )
                                        })}
                                </select>

                                <select
                                    className="input_consulta"
                                    name="medico"
                                    id="medico"
                                    value={idMedico}
                                    onChange={(campo) => setIdMedico(campo.target.value)}>
                                    <option value="0">Nome Médico</option>
                                    {
                                        listaMedico.map((medico) => {
                                            return (
                                                <option key={medico.idMedico} value={medico.idMedico}>
                                                    {medico.idUsuarioNavigation.nome}
                                                </option>
                                            )
                                        })}
                                </select>


                                
                                {/* <input
                                    className="input_consulta"
                                    type="text"
                                    name="text"
                                    //value={descricao}
                                    placeholder=" Descrição"
                                    onChange={(campo) => setDescri }
                                /> */}

                                <input
                                    className="input_consulta"
                                    type="datetime-local"
                                    name="data"
                                    value={dataConsulta}
                                    onChange={(campo) => setDataConsulta (campo.target.value) }
                                />

                                <div className="btn_cadastrar_consulta">
                                    {isLoading && (
                                        <button disabled className='btn_consulta' type='submit'>
                                            Carregando...
                                        </button>
                                    )}
                                    {!isLoading && (
                                        <button className='btn_consulta' type='submit'>
                                            Cadastrar
                                        </button>
                                    )}




                                    {/* <button
                                        type="submit"
                                        className="btn_consulta"
                                    >
                                        Cadastrar
                                    </button> */}
                                </div>
                            </div>
                        </form>
                    </div>
                </section>
            </main>

            <footer>
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

