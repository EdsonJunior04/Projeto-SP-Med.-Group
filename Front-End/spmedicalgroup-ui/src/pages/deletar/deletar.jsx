import React from 'react';
import { Link } from "react-router-dom";

import api from '../../services/api';
import '../../Assets/CSS/consultasAdm.css';

import logo from '../../Assets/img/Sp Medical Grouplogo.svg';


class deletar extends React.Component {
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
            dataConsulta: new Date(),
            isLoading: false
        };
    };



    buscarMedicos = async () => {
        try {

            const resposta = await api.get('/Medicos', {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
            if (resposta.status === 200) {
                this.setState({ listaMedicos: resposta.data });
            }
        }

        catch (error) {
            console.warn(error)
        }
    };

    buscarPacientes = async () => {
        try {

            const resposta = await api.get('/Pacientes', {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
            if (resposta.status === 200) {
                this.setState({ listaPacientes: resposta.data.lista });
            }
        }

        catch (error) {
            console.warn(error)
        }
    };

    buscarConsulta = async () => {
        try {


            const resposta = await api.get('/Consultas', {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
            if (resposta.status === 200) {
                this.setState({ listaConsultas: resposta.data });
            }
        }

        catch (error) {
            console.warn(error)
        }


    };


    componentDidMount() {
        this.buscarConsulta();
        this.buscarMedicos();
        this.buscarPacientes();
    };

    logout = async () => {
        localStorage.removeItem('usuario-login');
        this.props.history.push('/');
    };



    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    };

    deletarConsulta = async (ev) => {
        ev.preventDefault();
        try {


            const resposta = await api.delete('/Consultas/Remover', {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
            if (resposta.status === 200) {
                this.setState({ listaConsultas: resposta.data });
            }
        }

        catch (error) {
            console.warn(error)
        }


    };


    cadastrarConsulta = item => {
        try {
            this.setState({ isLoading: true });



            const resposta = api.post('/Consultas', {
                idPaciente: this.state.idPaciente,
                idMedico: this.state.idMedico,
                idSituacao: this.state.idSituacao,
                descricao: this.state.descricao,
                dataConsulta: new Date(this.state.dataConsulta)
            },
                {
                    headers: {
                        Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
                    },
                },
            );
            if (resposta.status === 201) {
                console.warn('Consulta realizada com sucesso.');
            } else {
                console.warn('Falha ao Cadastrar Consulta.');
            }
        } catch (error) {
            console.warn(error);
        }


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
                            DELETAR
                        </div>
                        <div>
                            <button className='btn_sair' onClick={this.logout} >Sair</button>
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
                                    <th>Situação</th>
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
                                                <td>{consulta.idSituacaoNavigation.descricao}</td>
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


                    
                    {/* Deletar Consulta */}

                    <div className="afastar_list_consulta">
                        <section className="cadastro_consulta grid ">
                            <h2 className="letra_tam">Cadastro de Consultas</h2>
                            <div className="cadastro_ajuste_consulta">
                                <form onSubmit={this.deletarConsulta} >
                                    <div>

                                        <select
                                            className="input_alterar"
                                            name="consulta"
                                            id="consulta"
                                            value={this.state.idConsulta}
                                            onChange={this.atualizaStateCampo}
                                        >
                                            <option value="0">Selecione a Consulta</option>
                                            {
                                                this.state.listaConsultas.map((consulta) => {
                                                    return (
                                                        <option key={consulta.idConsulta} value={consulta.idConsulta}>
                                                            Id: {consulta.idConsulta} / Paciente: {consulta.idPacienteNavigation.idUsuarioNavigation.nome} / Medico:{consulta.idMedicoNavigation.idUsuarioNavigation.nome} / Data:{Intl.DateTimeFormat("pt-BR", {
                                                                year: 'numeric', month: 'numeric', day: 'numeric',
                                                                hour: 'numeric', minute: 'numeric', hour12: false
                                                            }).format(new Date(consulta.dataConsulta))}
                                                        </option>
                                                    )
                                                })}
                                        </select>
                                        <div className="btn_cadastrar_consulta">

                                            {this.state.isLoading && (
                                                <button className="btn_consultaAdm" disabled>
                                                    Loading...{' '}
                                                </button>
                                            )}

                                            {this.state.isLoading === false && (
                                                <button className="btn_consultaAdm" >Deletar</button>
                                            )}
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </section>
                    </div>
                </main>

                <footer>
                    <div className="container_footer afastar_list_consulta">
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
export default deletar;