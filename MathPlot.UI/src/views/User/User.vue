<template>
    <b-container fluid>
        <b-row v-if="User != null">
            <b-col cols="3">
            </b-col>
            <b-col>
                <h3>Изменение информации о себе </h3>
               <form id="postUserData">
                   <label for="postIserDataFirstName">Имя</label>
                   <input type="text" class="form-control" v-model="User['firstName']" id="postIserDataFirstName">

                   <label for="postIserDataLastName">Фамилия</label>
                   <input type="text" class="form-control" v-model="User['lastName']" id="postIserDataLastName">

                    <label for="postUserDataLogin">Логин</label>
                    <input type="Login" class="form-control" v-model="User['login']" id="postUserDataLogin">

                    <label for="postUserDataEmail">Почта</label>
                    <input type="Email" class="form-control" id="postUserDataEmail" v-model="User['email']">

                    <label for="postUserDataPassWord">Старый пароль</label>
                    <input type="text" class="form-control" id="postUserDataPassWord" v-model="User['password']" >

                    <label for="postUserDataPassWordTwo">Новый пароль</label>
                    <input type="Password" class="form-control" id="postUserDataPassWordTwo"  v-model="newPassword" >

                    <input type="file" @change="onFileChange" />

                    <b-button type="button" variant="secondary" style="margin-top: 5px" v-on:click="SaveUser" >Сохранить</b-button>
               </form>
            </b-col>
            <b-col cols="3">
                <b-img :src="require('../../UserImages/'+User['login']+'/'+User['imagePath'])"
                 rounded="circle" 
                 v-bind="mainProps" 
                 style="margin-top: 90px " 
                 v-if="User['imagePath'] != null"></b-img>
                <b-img v-bind="defaultProps" rounded="circle" v-if="User['imagePath'] == null"  style="margin-top: 90px "></b-img>
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
export default {
    data(){
        return{
            User: null,
            newPassword : "",
            file: null,
            mainProps: {width: 200, height: 200},
             defaultProps: { blank: true, blankColor: '#777', width: 200, height: 200 }
        }
    },
    mounted(){
        this.GetUsers()
    },
    methods:{
        async GetUsers(){
            const response = await fetch("http://localhost:56063/api/user/" + sessionStorage.getItem("login"),
            {
                method: "GET",
                headers: {"Accept": "application/json"}
            });
            if(response.status >=200 && response.status <= 299){
                this.User = await response.json()
            }
            else{
                console.log(response.status, response.statusText);
            }
        },
        onFileChange(e) {
            this.file = e.target.files[0];
        },
        async SaveUser(){
            const response = await fetch("http://localhost:56063/api/user", {
                method: "PUT",
                headers: { "Accept": "application/json", "Content-Type": "application/json" },
                body: JSON.stringify({
                    Id :this.User['id'],
                    FirstName : this.User['firstName'],
                    LastName: this.User['lastName'],
                    Login: this.User['login'],
                    Genre: this.User['genre'],
                    Email: this.User['email'],
                    Phone: this.User['phone'],
                    Password: this.newPassword == ""?this.User['password']:this.newPassword ,
                    ImagePath: null
                })
            });
            if(response.status >=200 && response.status <= 299){
                this.User = await response.json()
                console.log(this.User)
                if(this.file != null){
                    let formdata = new FormData()
                    formdata.append('file',this.file)
                    formdata.append('login',this.User['login'])
                    const response = await fetch("http://localhost:56063/api/UserImage", {
                        method: "PUT",
                        body: formdata
                    });
                    if(response.status >=200 && response.status <= 299){
                        this.User = await response.json()
                        console.log(this.User)
                    }
                    else{
                        console.log(response.status, response.statusText);
                    }
                }
            }
            else{
                console.log(response.status, response.statusText);
            }

        }
    }

}
</script>