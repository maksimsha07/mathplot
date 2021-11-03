<template>
<div>
    <header class="header">
            <b-navbar type="dark" variant="info">
                <div class="container-fluid">
                    <b-navbar-brand href="#" style="margin-left: 5px">
                        <img src="../../assets/function.png" width="30" height="30" class="d-inline-block align-top" alt="Func">
                        MathPlot
                    </b-navbar-brand>
                    <div class="d-flex justify-content-center">
                        <b-nav-item-dropdown text="Графики" right style="list-style-type: none" >
                            <router-link
                            v-for="link in linksgraf"
                            :key="link.url"
                            tag="li"
                            :to="link.url"
                            >                      
                            <b-dropdown-item href="to" id="functionsLayouts">{{link.title}}</b-dropdown-item>
                            </router-link>
                        </b-nav-item-dropdown>
                        <b-nav-item-dropdown text="Теория" right style="list-style-type: none">
                            <router-link
                            v-for="link in linkstheory"
                            :key="link.url"
                            tag="li"
                            :to="link.url"
                            >                      
                            <b-dropdown-item href="to" id="functionsLayouts">{{link.title}}</b-dropdown-item>
                            </router-link>
                        </b-nav-item-dropdown>
                    </div>
                        <div v-if="autorize === false" class="d-flex">                  
                            <b-button @click="$bvModal.show('registrationsModal')" type="button" id="buttonSing" variant="secondary">Sing up</b-button>
                            <b-button @click="$bvModal.show('authModal')" type="button" variant="secondary" style="margin: 0px 5px 0px 5px">Sing in</b-button>
                        </div>
                        <div v-if="autorize === true" class="d-flex">                  
                            <b-button type ="submit" variant="secondary" v-on:click="logouts">Logout</b-button>
                            <p>{{logn}}</p>
                        </div>
                </div>
            </b-navbar>
    </header>

    <!-- Modal Sing UP -->
    <b-modal
        id ="registrationsModal"
        ref = "modal"
        title="Sing Up"
        hide-footer
        >
        <div class="container overflow-hidden">
            <div id="errors" class="alert alert-danger" style="display:none;"></div>
            <form id="registrationForm" @submit.prevent = "registerClick">
                <div class="form-group row ">
                    <div class="form-group col-md-6">
                        <label for="registrationInputFirstName">FirstName</label>
                        <input type="text" class="form-control" v-model="FirstName" id="registrationInputFirstName" placeholder="Enter FirstName">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="registrationInputLastName">LastName</label>
                        <input type="text" class="form-control" v-model="LastName" id="registrationInputLastName" placeholder="Enter LastName">
                    </div>
                </div>
                <div class="form-group" id="modalrowsize">
                    <label for="registrationInputLogin">Login</label>
                    <input type="Login" class="form-control" v-model="Login" id="registrationInputLogin" placeholder="Enter Login">
                </div>
                <div class="form-group row" id="modalrowsize">
                    <div class="form-group col-md-6">
                        <legend class="col-form-label col-sm-2 pt-0">Genres</legend>
                        <div class="form-group row">
                            <div class="form-check col-md-6" style="margin-left:15px">
                                <input class="form-check-input" type="radio" name="IsMale" id="registrationRadioMale" value="true"  v-model="Genre" checked>
                                <label class="form-check-label" for="registrationRadioMale">
                                    Male
                                </label>
                            </div>
                            <div class="form-check col-md-4">
                                <input class="form-check-input" type="radio" name="IsMale" id="registrationRadioFemale" value="false"  v-model="Genre"  checked>
                                <label class="form-check-label" for="">
                                    Female
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group row" id="modalrowsize">
                    <div class="form-group col-md-6">
                        <label for="registrationInputEmail">Email Address</label>
                        <input type="Email" class="form-control" id="registrationInputEmail" v-model="Email"  placeholder="Enter email">
                    </div>
                    <div class="form-group col-md-6">
                        <label for="registrationInputTelephone">Phone Number</label>
                        <input type="Phone" class="form-control" id="registrationInputTelephone"  v-model="Phone">
                    </div>
                </div>
                <div class="form-group row" id="modalrowsize">
                    <div class="form-group col-md-6">
                        <label for="registrationInputPassword">Password</label>
                        <input type="Password" class="form-control" id="registrationInputPassword" placeholder="Enter Password"  v-model="Password" >
                    </div>
                    <div class="form-group col-md-6">
                        <label for="registrationInputPasswordReturn">Password</label>
                        <input type="Password" class="form-control" id="registrationInputPasswordReturn" placeholder="Enter Password">
                    </div>
                </div>
            </form>
        </div>
            <div class="modal-footer">
                <b-button type="submit" form="registrationForm" variant="secondary">Submit</b-button>
            </div>
    </b-modal>
    <!--Modal Sing Up-->
    <!-- Modal Sing IN -->
     <b-modal
        id ="authModal"
        ref = "modal"
        title="Sing in"
        hide-footer
        >
         <div class="container overflow-hidden">
                <form id="authForm">
                    <div class="form-group">
                        <label for="authInputEmail">Login</label>
                        <input type="Login" class="form-control" id="authInputEmail" placeholder="Enter Login" v-model="Login">
                    </div>
                    <div class="form-group" id="modalrowsize">
                        <label for="authInputPassword">Password</label>
                        <input type="Password" class="form-control" id="authInputPassword" placeholder="Enter Password" v-model="Password">
                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <b-button type="button" form="authForm" variant="secondary" v-on:click="getTokenAsync">Submit</b-button>
            </div>
     </b-modal>
</div>
</template>

<script>
import { uuid } from 'vue-uuid';
var tokenKey = "accessToken";
var lg = "login";
export default{
    data(){
        return{
            Id: uuid.v1(),
            logn: sessionStorage.getItem(lg),
            FirstName : "",
            LastName: "",
            Login: "",
            Genre: "true",
            Email: null,
            Phone: null,
            Password: "",
            autorize: sessionStorage.getItem(tokenKey) === null ? false:true,
            linksgraf:[
                {title:'Отображение планка',url:'/MappPlank'},
                {title:'Логистическое Отображение',url:'/MappLogistic'}
            ],
            linkstheory: [
                {title:'Одномерные точечные отображения', url: '/OneDimensionalMappings/0'},
                {title:'Двумерные точечные одображения', url: '/TwoDimensionalMappings/0'}
            ]
        }
    },
    methods:
    {
        async GetUsers(){
            const response = await fetch("http://localhost:56063/api/user",
            {
                method: "GET",
                headers: {"Accept": "application/json"}
            });
            if(response.status >=200 && response.status <= 299){
                console.log(response.json());
            }
            else{
                console.log(response.status, response.statusText);
            }
        },
        async registerClick(){
           const response = await fetch("http://localhost:56063/api/user",
           {
               method: "POST",
               headers: {"Accept": "application/json", "Content-Type": "application/json"},
               body: JSON.stringify({
                    Id :this.Id,
                    FirstName : this.FirstName,
                    LastName: this.LastName,
                    Login: this.Login,
                    Genre: this.Genre == "true" ? true : false,
                    Email: this.Email,
                    Phone: this.Phone == null ? null :Number(this.Phone),
                    Password: this.Password
               })
           });
           if(response.ok === true){
               console.log(response.json());
           }
           else{
              const errorData = await response.json();             
              console.log("errors",errorData);
              this.clearBox("errors");
              if(errorData.errors){
                  if(errorData.errors["Login"]){
                      this.addError(errorData.errors["Login"]);
                  }
                   if(errorData.errors["FirstName"]){
                      this.addError(errorData.errors["FirstName"]);
                  }
                   if(errorData.errors["LastName"]){
                      this.addError(errorData.errors["LastName"]);
                  }
                 if(errorData.errors["Password"]){
                        this.addError(errorData.errors["Password"]);
                   }                  
              }
              if(errorData["Login"]){
                 this.addError(errorData["Login"]);
              }
              if(errorData["FirstName"]){
                 this.addError(errorData["FirstName"]);
              }
              if(errorData["LastName"]){
                 this.addError(errorData["LastName"]);
              }
              if(errorData["Password"]){
                 this.addError(errorData["Password"]);
              }
              document.getElementById("errors").style.display = "block";
           }
        },
        addError(errors) {
            errors.forEach(error => {
                const p = document.createElement("p");
                p.append(error);
                document.getElementById("errors").append(p);
            });
        },
        clearBox(elementID)
        {
            var div = document.getElementById(elementID);
            while(div.firstChild){
                div.removeChild(div.firstChild);
             }
        },
        async getTokenAsync(){
            const response = await fetch("http://localhost:56063/api/Auth",{
                method: "POST",
                headers: {"Accept": "appication/json","Content-Type": "application/json"},
                body: JSON.stringify({
                    login: this.Login,
                    password: this.Password
               })
            });
            console.log(this.Login +" " + this.Password)
            const data = await response.json();
            if(response.ok === true){
                sessionStorage.setItem(tokenKey,data.access_token);
                sessionStorage.setItem(lg,this.Login);
                console.log(data.access_token);
            }
            else{
                console.log("Error: ", response.status, data.errorText);
            }
        },
        async getLogin(){
             const token = sessionStorage.getItem(tokenKey);
             const response = await fetch("http://localhost:56063/api/user/getlogin",{
                method: "GET",
                headers: {"Accept": "appication/json",
                        "Authorization": "Bearer " + token}
            });
            if (response.ok === true) {
                 
                const data = await response.json();
                console.log(data)
            }
            else
                console.log("Status: ", response.status);
        },
        logouts(){
            sessionStorage.removeItem(tokenKey);
            this.autorize = false;
            window.location.reload();
        }

    }
}
</script>