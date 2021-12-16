import '../../Assets/CSS/header.css'
import { useState } from 'react'

export default function Header() {

    const [active, setMode] = useState(false);
    const ToggleMode = () => {
        setMode(!active)
    }

    return (
        <div className='App'>
            <div className={active ? "icon iconActive" : "icon"} onClick={ToggleMode}>
                <div className="hamburguer hamburguerIcon"></div>
            </div>
            <div className={active ? 'menu menuOpen' : 'meun menuClose'}>
                <div className='list'>
                    <ul className='listItems'>
                        <li>HOME</li>
                        <li>PRODUCTS</li>
                        <li>CONSTACT</li>
                        <li>ABOUT US</li>
                    </ul>
                </div>
            </div>
        </div>
    )
}