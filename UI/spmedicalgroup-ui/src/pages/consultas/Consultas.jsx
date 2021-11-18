import React from 'react';
import { Link } from "react-router-dom";


import '../../Assets/CSS/Consultas.css';

import logo from '../../Assets/img/Sp Medical Grouplogo.svg';


class Consultas extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: [],
            titulo: ''
        };
    };

    buscarConsultas = () => {
        console.log("Agora vamos fazer a chamada para a API")
        fetch('http://localhost:5000/api/Consultas')

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaConsultas: dados }))

            .catch(erro => console.log(erro))
    }

    componentDidMount() {
        this.buscarConsultas()
        //
    };

    render() {
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
                                    this.state.listaConsultas.map((consulta) => {
                                        return (
                                            <tr key={consulta.idConsulta} >
                                                <td>{consulta.idConsulta}</td>
                                                <td>{consulta.idPacienteNavigation.idUsuarioNavigation.nome}</td>
                                                <td>{consulta.idMedicoNavigation.idUsuarioNavigation.nome}</td>
                                                <td>{consulta.descricao}</td>
                                                <td>{ Intl.DateTimeFormat("pt-BR", {
                                                    year: 'numeric', month: 'short', day: 'numeric',
                                                    hour: 'numeric', minute: 'numeric', hour12: false
                                                }).format(new Date(consulta.dataConsulta)) }</td>
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
                            <form >

                                <input
                                    className="input_consulta"
                                    type="text"
                                    name="email"
                                    //value={this.state.email}
                                    placeholder=" Nome do Paciente"
                                // onChange={  }
                                />
                                <input
                                    className="input_consulta"
                                    type="text"
                                    name="Name"
                                    // value={this.state.email}
                                    placeholder=" Nome do Médico"
                                // onChange={  }
                                />

                                <input
                                    className="input_consulta"
                                    type="text"
                                    name="Name"
                                    // value={this.state.email}
                                    placeholder=" Modo"
                                // onChange={  }
                                />

                                <input
                                    className="input_consulta"
                                    type="date"
                                    name="Data"
                                    // value={this.state.email}
                                    placeholder=" userName"
                                // onChange={  }
                                />

                                <div className="btn_cadastrar_consulta">
                                    <button
                                        type="submit"
                                        className="btn_consulta"
                                    >
                                        Cadastrar
                                    </button>
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
};
export default Consultas;