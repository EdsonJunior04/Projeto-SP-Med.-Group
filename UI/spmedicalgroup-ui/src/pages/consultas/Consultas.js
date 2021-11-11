import React from 'react';

class Consultas extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas: [ { idConsulta: 1, titulo : 'Fisioterapia'}, {idConsulta: 2, titulo: 'Cardiologista' } ],
            titulo : ''
        };
    };

buscarConsultas = () => {
    console.log("Agora vamos fazer a chamada para a API")
    fetch('http://localhost:5000/')
}

    componentDidMount(){
        this.buscarConsultas()
        //
    };

    render(){
        return(
            //JSX
            <div>
                <main>
                    {/* Lista de tipos de consulta */}
                    <section>
                        <h2>Lista de Consultas</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Consulta</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaConsultas.map( (consulta) => {
                                        return(
                                            <tr key={consulta.idConsulta} >
                                                <td>{consulta.idConsulta}</td>
                                                <td>{consulta.titulo}</td>
                                            </tr>
                                        )
                                    } )
                                }
                            </tbody>
                        </table>
                    </section>
                    {/* Cadastro de tipos de consulta */}
                </main>
            </div>
        )
    }
};
export default Consultas;