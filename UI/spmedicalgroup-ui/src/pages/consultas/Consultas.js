import React from 'react';
import { Link } from "react-router-dom";


import '../../Assets/CSS/Consultas.css';

import logo from '../../Assets/img/Sp Medical Grouplogo.svg';


class Consultas extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: [{ idConsulta: 1, titulo: 'Fisioterapia' }, { idConsulta: 2, titulo: 'Cardiologista' }],
            titulo: ''
        };
    };

    buscarConsultas = () => {
        console.log("Agora vamos fazer a chamada para a API")
        fetch('http://localhost:5000/Consultas')
    }

        componentDidMount(){
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
                            <Link to="/cadastro" className="links_header"> Cadastro </Link>
                        </div>

                    </div>
                </header>

                <main className="afastar_list_consulta ">
                    {/* Lista de tipos de consulta */}
                    <section className="lista_consulta grid">
                        <h2>Lista de Consultas</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Paciente</th>
                                    <th>Médico</th>
                                    <th>Epecialidade</th>
                                    <th>Data</th>
                                    <th>Status</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaConsultas.map((consulta) => {
                                        return (
                                            <tr key={consulta.idConsulta} >
                                                <td>{consulta.idConsulta}</td>
                                                <td>{consulta.titulo}</td>
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

                            <input
                                className="input_consulta"
                                type="text"
                                name="email"
                                // value={this.state.email}
                                placeholder=" Nome do Paciente"
                            // onChange={  }
                            />
                            <input
                                className="input_consulta"
                                type="text"
                                name="email"
                                // value={this.state.email}
                                placeholder=" Nome do Médico"
                            // onChange={  }
                            />

                            <input
                                className="input_consulta"
                                type="text"
                                name="email"
                                // value={this.state.email}
                                placeholder=" Especialidade"
                            // onChange={  }
                            />

                            <input
                                className="input_consulta"
                                type="date"
                                name="email"
                                // value={this.state.email}
                                placeholder=" userName"
                            // onChange={  }
                            />
                        </div>

                        <button
                            type="submit"
                            className="btn_consulta"
                        >
                            Cadastrar
                        </button>

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