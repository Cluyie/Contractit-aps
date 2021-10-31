const loginBox = document.querySelector('#login-box');
const userName = document.querySelector('#username');
const passWord = document.querySelector('#password');

loginBox.addEventListener('submit', onSubmit);

function onSubmit(e) {
    e.preventDefault();
    
    if(userName.value === '' || passWord.value === '') {
        alert('not filled');
    } else {
        console.log('succes');
    }
}


