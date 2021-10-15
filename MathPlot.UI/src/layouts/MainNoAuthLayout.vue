<template>
<div>
    <header class="header">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <a class="navbar-brand" href="">
                    <img src="../assets/function.png" width="30" height="30" class="d-inline-block align-top" alt="" loading="lazy">
                    MathPlot
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse flex-grow-1 justify-content-center" id="navbarSupportedContent">
            <ul class="navbar-nav mx-auto">
                <li class="b-nav-item">
                <a class="nav-link active" aria-current="page" href="#">Home</a>
                </li>
                <li class="nav-item">
                <a class="nav-link" href="#">Link</a>   
                </li>
                <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Dropdown
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                    <li><a class="dropdown-item" href="#">Action</a></li>
                    <li><a class="dropdown-item" href="#">Another action</a></li>
                    <li><hr class="dropdown-divider"></li>
                    <li><a class="dropdown-item" href="#">Something else here</a></li>
                </ul>
                </li>
                <li class="nav-item">
                <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Disabled</a>
                </li>
            </ul>
            <form class="d-flex">
                <b-button @click="$bvModal.show('registrationsModal')" type="button" id="buttonSing" class="btn btn-outline-primary mr-md-2">Sing up</b-button>
                <button type="button" class="btn btn-outline-primary mr-md-2" data-bs-toggle="modal" data-bs-target="#authModal" style="margin-left: 5px">Sing in</button>
            </form>
            </div>
        </div>
        </nav>
    </header>

    <!-- Modal Sing UP -->
    <b-modal
        id ="registrationsModal"
        ref = "modal"
        title="Sing Up"
        >
        <div class="container overflow-hidden">
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
                        <label for="registrationInputBirthday">Birthday</label>
                        <datetime v-model="Birthday" id ="registrationInputBirthday"></datetime>
                    </div>
                    <div class="form-group col-md-6">
                        <legend class="col-form-label col-sm-2 pt-0">Genres</legend>
                        <div class="form-group row">
                            <div class="form-check col-md-6 ">
                                <input class="form-check-input" type="radio" name="gridRadios" id="registrationRadioMale" value=true  v-model="Genre" checked>
                                <label class="form-check-label" for="registrationRadioMale">
                                    Male
                                </label>
                            </div>
                            <div class="form-check col-md-4">
                                <input class="form-check-input" type="radio" name="gridRadios" id="registrationRadioFemale" value=false  v-model="Genre"  checked>
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
                        <input type="Phone" class="form-control" id="registrationInputTelephone"  v-model="Phone" >
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
                <button type="submit" form="registrationForm" class="btn btn-primary">Submit</button>
            </div>
    </b-modal>
 
    <!--Modal Sing Up-->
    <!-- Modal Sing IN -->
    <div class="modal fade" id="authModal" tabindex="-1" role="dialog" aria-bs-labelledby="authModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="authModalLabel">Sing in</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-bs-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container overflow-hidden">
                        <form id="authForm">
                            <div class="form-group">
                                <label for="authInputEmail">Login</label>
                                <input type="Login" class="form-control" id="authInputEmail" placeholder="Enter Login">
                            </div>
                            <div class="form-group" id="modalrowsize">
                                <label for="authInputPassword">Password</label>
                                <input type="Password" class="form-control" id="authInputPassword" placeholder="Enter Password">
                            </div>
                        </form>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" form="authForm" class="btn btn-primary">Submit</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Sing IN -->

    <router-view />


    <!--Footer -->
    <footer class="bg-light text-center text-lg-start fixed-bottom">
        <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
            � 2020 Copyright:
        </div>
    </footer>
</div>
</template>


<script>
import { uuid } from 'vue-uuid';

export default{
    data(){
        return{
            Id: uuid.v1(),
            FirstName : "",
            LastName: "",
            Login: "",
            Birthday: null,
            Genre: true,
            Email: "",
            Phone: null,
            Password: ""
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
            console.log(this.data);
        }
    }
}
</script>

