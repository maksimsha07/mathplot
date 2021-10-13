<template>
<div class="app-mainWithoutLogin-layout">
    <header class="header">
        <nav class="navbar navbar-light bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="">
                    <img src="../assets/function.png" width="30" height="30" class="d-inline-block align-top" alt="" loading="lazy">
                    MathPlot
                </a>
                <h2>Main</h2>
                <div class="d-flex">
                    <button type="button" id="buttonSing" class="btn btn-primary mr-md-2" data-bs-toggle="modal" data-bs-target="#registrationsModal">Sing up</button>
                    <button type="button" class="btn btn-primary mr-md-2" data-bs-toggle="modal" data-bs-target="#authModal">Sing in</button>
                </div>
            </div>
        </nav>
    </header>

    <!-- Modal Sing UP -->
    <div class="modal fade" id="registrationsModal" tabindex="-1" role="dialog" aria-bs-labelledby="registrationsModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="registrationsModalLabel">Sing Up</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-bs-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container overflow-hidden">


                        <form id="registrationForm">

                            <div class="form-group row ">
                                <div class="form-group col-md-6">
                                    <label for="registrationInputFirstName">FirstName</label>
                                    <input type="text" class="form-control" id="registrationInputFirstName" placeholder="Enter FirstName">
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="registrationInputLastName">LastName</label>
                                    <input type="text" class="form-control" id="registrationInputLastName" placeholder="Enter LastName">
                                </div>
                            </div>

                            <div class="form-group" id="modalrowsize">
                                <label for="registrationInputLogin">Login</label>
                                <input type="Login" class="form-control" id="registrationInputLogin" placeholder="Enter Login">
                            </div>

                            <div class="form-group row" id="modalrowsize">
                                <div class="form-group col-md-6">
                                    <label for="registrationInputBirthday">Birthday</label>
                                    <input type="date" class="form-control" id="registrationInputBirthday">
                                </div>
                                <div class="form-group col-md-6">
                                    <legend class="col-form-label col-sm-2 pt-0">Genres</legend>
                                    <div class="form-group row">
                                        <div class="form-check col-md-6 ">
                                            <input class="form-check-input" type="radio" name="gridRadios" id="registrationRadioMale" value="option1" checked>
                                            <label class="form-check-label" for="registrationRadioMale">
                                                Male
                                            </label>
                                        </div>
                                        <div class="form-check col-md-4">
                                            <input class="form-check-input" type="radio" name="gridRadios" id="registrationRadioFemale" value="option1" checked>
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
                                    <input type="Email" class="form-control" id="registrationInputEmail" placeholder="Enter email">
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="registrationInputTelephone">Phone Number</label>
                                    <input type="Phone" class="form-control" id="registrationInputTelephone">
                                </div>
                            </div>

                            <div class="form-group row" id="modalrowsize">
                                <div class="form-group col-md-6">
                                    <label for="registrationInputPassword">Password</label>
                                    <input type="Password" class="form-control" id="registrationInputPassword" placeholder="Enter Password">
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="registrationInputPasswordReturn">Password</label>
                                    <input type="Password" class="form-control" id="registrationInputPasswordReturn" placeholder="Enter Password">
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" form="registrationForm" class="btn btn-primary">Submit</button>
                </div>

            </div>
        </div>
    </div>
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
    <footer class="bg-light text-center text-lg-start">
        <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
            � 2020 Copyright:
        </div>
    </footer>
</div>
</template>
