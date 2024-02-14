import {getParamUrl, sendEmail} from './services.js';
import { Notifications } from './notifications.js';

const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);

(async()=>{
    const navMenu = $('#nav-menu');
    const navToggle = $('#nav-toggle');
    const main = $('.main');
    const closeMenu = ()=>{
        navMenu.classList.remove('show');
        window.removeEventListener('scroll', closeMenu);
        main.removeEventListener('click', closeMenu);
    }
    ;
    if (navToggle) {
        navToggle.addEventListener('click', ()=>{
            const state = navMenu.classList.toggle('show');
            if (state) {
                window.addEventListener('scroll', closeMenu);
                main.addEventListener('click', closeMenu);
            } else {
                window.removeEventListener('scroll', closeMenu);
                main.removeEventListener('click', closeMenu);
            }
        }
        );
    }
    const toggleShadowHeader = ()=>{
        const nav = $('#header');
        const scroll = window.scrollY;
        const height = nav.offsetHeight;
        if (scroll > height) {
            nav.classList.add('shadow');
        } else {
            nav.classList.remove('shadow');
        }
    }
    ;
    window.addEventListener('scroll', toggleShadowHeader);
}
)();
(async()=>{
    const themeToggle = $('#theme-toggle');
    const getPreferenceColor = ()=>{
        const color = window.matchMedia('(prefers-color-scheme: dark)');
        return color.matches ? 'dark' : 'light';
    }
    ;
    const savePreferenceTheme = (theme)=>{
        localStorage.setItem('theme', theme);
    }
    ;
    const getPreferenceTheme = ()=>{
        const theme = localStorage.getItem('theme');
        return theme || getPreferenceColor();
    }
    ;
    const setTheme = (theme)=>{
        const html = document.documentElement;
        html.setAttribute('theme', theme);
        themeToggle.setAttribute('theme', theme);
        savePreferenceTheme(theme);
    }
    ;
    const toggleTheme = ()=>{
        const html = document.documentElement;
        const state = html.getAttribute('theme') === 'dark';
        setTheme(state ? 'light' : 'dark');
    }
    ;
    const initTheme = ()=>{
        const theme = getPreferenceTheme();
        setTheme(theme);
    }
    ;
    const mql = window.matchMedia('(prefers-color-scheme: dark)');
    mql.addEventListener('change', (e)=>setTheme(e.matches ? 'dark' : 'light'));
    initTheme();
    themeToggle.addEventListener('click', toggleTheme);
}
)();
(()=>{
    const notifications = new Notifications();
    const beforeUnloadListener = (event)=>{
        event.preventDefault();
        event.returnValue = 'Are you sure you want to exit?';
        return event.returnValue;
    };
    const validateEmail = (email)=>/^(?:(?:[^<>()[\]\\.,;:\s@"]+(?:\.[^<>()[\]\\.,;:\s@"]+)*)|(?:".+"))@(?:(?:\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(?:(?:[a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(email);
    const validateAlpha = (Alpha) => /^[a-zA-Z\u00C0-\u00FF]{2,} +[a-zA-z\u00C0-\u00FF]{2,}[a-zA-z\u00C0-\u00FF ]*$/.test(Alpha);
    const validateName = (name)=>/^[a-zA-Z\u00C0-\u00FF]{2,}$/.test(name);
    const validateNameOrEmpty = (name) => /^[a-zA-Z\u00C0-\u00FF]*$/.test(name);
    const validateSubject = (subject) => /^[\w\u00C0-\u00FF :;.,()¡!¿?'`"#%]{2,}$/.test(subject);
    const validateMessage = (message)=>/^.{2,}$/gm.test(message);
    const validateMessageOrEmpty = (message) => /^.*$/gm.test(message);
    const validate = (input, showNotificationError = false) => {
        const errorMessages = {
            TxtFirstName: 'Primer nombre no válido',
            TxtSecondName: 'Segundo nombre no válido',
            TxtFirstLastName: 'Primer apellido no válido',
            TxtSecondLastName: 'Segundo apellido no válido',
            name: 'Nombre no válido',
            email: 'Correo no válido',
            subject: 'Asunto no válido',
            message: 'Mensaje no válido',
            TxtIdNumber: 'Número de identificación no válido',
            TxtCountry: 'País no válido',
            TxtCity: 'Ciudad no válida',
            TxtState: 'Estado no válido',
            TxtNeighborhood: 'Barrio no válido',
            TxtAddress: 'Dirección no válida',
        };
        const value = input.value;
        const type = input.getAttribute('id');
        const parent = input.parentNode;
        const validations = {
            name: validateName(value),
            email: validateEmail(value),
            subject: validateSubject(value),
            message: validateMessage(value),
            TxtFirstName: validateName(value),
            TxtSecondName: validateNameOrEmpty(value),
            TxtFirstLastName: validateName(value),
            TxtSecondLastName: validateNameOrEmpty(value),
            DropListIdType: true,
            TxtIdNumber: validateMessage(value),
            TxtCountry: validateMessage(value),
            TxtCity: validateMessage(value),
            TxtState: validateMessage(value),
            TxtNeighborhood: validateMessage(value),
            TxtAddress: validateMessage(value),
        };
        const valid = validations[type];
        if (valid) {
            parent.classList.remove('invalid');
            parent.classList.add('valid');
        } else if (valid === false) {
            parent.classList.remove('valid');
            parent.classList.add('invalid');
            if (showNotificationError) {
                notifications.sendNotification({
                    type: 'error',
                    title: 'Dato no valido',
                    message: errorMessages[type]
                });
            }
        }
        return valid;
    }
    ;
    const contactInputs = [...$$('.contact-input')];
    contactInputs.forEach((item)=>{
        item.addEventListener('focusout', ()=>{
            item.value = item.value.replace(/\n{3,}/gm, '\n\n').replace(/ {2,}/gm, ' ').replace(/(^ +| +$)/gm, '').replace(/([¿'"¡`])\s+([\w\u00C0-\u00FF])/gm, '$1$2').replace(/([\w\u00C0-\u00FF])\s+([?.,'";:!`])/gm, '$1$2').trim();
        }
        );
        item.addEventListener('change', ()=>{
            const isEmpty = contactInputs.every((input)=>input.value.trim() === '');
            if (isEmpty) {
                window.removeEventListener('beforeunload', beforeUnloadListener, {
                    capture: true
                });
            } else {
                window.addEventListener('beforeunload', beforeUnloadListener, {
                    capture: true
                });
            }
        }
        );
        item.addEventListener('input', validate.bind(null, item, false));
    });

    const customerName = $("#customerName");
    const TxtFirstName = $("#TxtFirstName");
    const TxtFirstLastName = $("#TxtFirstLastName");

    const updateCustomerName = () => {
        customerName.textContent = `${TxtFirstName.value} ${TxtFirstLastName.value}`;
    }

    if (customerName && TxtFirstName && TxtFirstLastName) {
        TxtFirstName.addEventListener("input", updateCustomerName);
        TxtFirstLastName.addEventListener("input", updateCustomerName);
        updateCustomerName();
    }

    window.validForm = () => {
        let formIsValid = true;
        contactInputs.forEach((item) => {
            if (!validate(item, true)) {
                formIsValid = false;
            }
        });

        if (formIsValid) {
            window.removeEventListener('beforeunload', beforeUnloadListener, {
                capture: true
            });
        }
        return formIsValid;
    }
}
)();
