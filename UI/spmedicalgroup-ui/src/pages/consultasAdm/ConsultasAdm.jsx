import React from 'react';
import { Link } from "react-router-dom";
import axios from 'axios';


import '../../Assets/CSS/consultasAdm.css';

import logo from '../../Assets/img/Sp Medical Grouplogo.svg';


class consultasAdm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: [],
            listaPacientes: [],
            listaMedicos: [],
            listaSituacao: [1, 2, 3],
            idSituacao: 0,
            idMedico: 0,
            idPaciente: 0,
            descricao: '',
            data: new Date(),

            isLoading: false
        };
    };

    buscarMedicos = () => {
        console.log("Agora vamos fazer a chamada para a API")
        fetch('http://localhost:5000/api/Medicos')

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaMedicos: dados }))

            .catch(erro => console.log(erro))
    }

    buscarPacientes = () => {
        console.log("Agora vamos fazer a chamada para a API")
        fetch('http://localhost:5000/api/Pacientes')

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaPacientes: dados }))

            .catch(erro => console.log(erro))
            
    }

    buscarConsultas = () => {
        console.log("Agora vamos fazer a chamada para a API")
        fetch('http://localhost:5000/api/Consultas')

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaConsultas: dados }))

            .catch(erro => console.log(erro))
    }

    componentDidMount() {
        this.buscarConsultas();
        this.buscarMedicos();
        //this.buscarPacientes();
    };



    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    };



    cadastrarConsulta = (event) => {
        event.defaultPrevented();
        this.setState({ isLoading: true });

        let consulta = {
            idPaciente: this.state.idPaciente,
            idMedico: this.state.idMedico,
            idSituacao: this.state.idSituacao,
            descricao: this.state.descricao,
            dataConsulta: new Date(this.state.data)
        };
        axios
            .post('http://localhost:5000/api/Consultas', consulta, {
                headers: {
                    authorization: 'Bearer ' + localStorage.getItem('usuario-login')
                },
            })

            .then((resposta) => {
                if (resposta.status === 201) {
                    console.log('Consulta Cadastrada!')
                    this.setState({ isLoading: false })
                }
            })

            .catch((erro) => {
                console.log(erro);
                this.setState({ isLoading: false });
            })
            .then(this.buscarConsultas)
    }

    

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
                            <p>Administrador</p>

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
                            <form onSubmit={this.cadastrarConsulta} >
                                <div>

                                    <select
                                        className="input_consulta"
                                        name="idPaciente"
                                        value={this.state.idPaciente}
                                        onChange={this.atualizaStateCampo}>
                                        <option value="0">Selecione o paciente</option>

                                        {
                                            this.state.listaPacientes.map((paciente) => {
                                                return (
                                                    <option key={paciente.idPaciente} value={paciente.idPaciente}>
                                                        {paciente.idUsuarioNavigation.nome}
                                                    </option>
                                                )
                                            })
                                        }
                                    </select>

                                    <select
                                        className="input_consulta"
                                        name="idMedico"
                                        value={this.state.idMedico}
                                        onChange={this.atualizaStateCampo}>
                                        <option value="0">Selecione o Médico</option>

                                        {
                                            this.state.listaMedicos.map((medico) => {
                                                return (
                                                    <option key={medico.idMedico} value={medico.idMedico}>
                                                        {medico.idUsuarioNavigation.nome}
                                                    </option>
                                                )
                                            })
                                        }
                                    </select>
                                    <select
                                        className="input_consulta"
                                        name="idSituacao"
                                        value={this.state.idSituacao}
                                        onChange={this.atualizaStateCampo}>
                                        <option value="0">Selecione a Situação</option>

                                        <option value={this.state.listaSituacao[0]}>Agendada</option>
                                        <option value={this.state.listaSituacao[1]}>Cancelada</option>
                                        <option value={this.state.listaSituacao[2]}>Realizada</option>


                                    </select>

                                    <input
                                        className="input_consulta"
                                        type="text"
                                        name="descricao"
                                        value={this.state.descricao}
                                        placeholder="Descrição"
                                        onChange={this.atualizaStateCampo}
                                    />

                                    <input
                                        className="input_consulta"
                                        type="datetime-local"
                                        name="dataConsulta"
                                        value={this.state.dataConsulta}
                                        onChange={this.atualizaStateCampo}
                                    />

                                    <div className="btn_cadastrar_consulta">

                                        {this.state.isLoading && (
                                            <button className="btn_consulta" type="submit" disabled>
                                                Loading...{' '}
                                            </button>
                                        )}

                                        {this.state.isLoading === false && (
                                            <button className="btn_consulta" type="submit">Cadastrar</button>
                                        )}
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
};
export default consultasAdm;