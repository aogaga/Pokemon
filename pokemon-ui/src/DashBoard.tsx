import React from 'react';
import Header from "./Header";
import PokemonTable from "./PokemonTable";

const DashBoard: React.FC = () =>{
    return (
        <div>
            <Header title={"POkemon"}/>

            <section className="main-page">
                <div className="container">
                    <div className="row">

                        <div className="col-3">
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Consequuntur culpa impedit
                                iusto
                                laudantium maiores, maxime minus possimus. A, ad amet blanditiis dignissimos eaque ex,
                                nisi,
                                nostrum obcaecati placeat quasi vel.
                            </p>
                        </div>

                        <div className="col-9">
                           <PokemonTable />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
}

export default DashBoard;