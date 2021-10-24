<template>
    <b-container fluid>
        <b-row>
            <b-col>
            </b-col>
            <b-col>
                <h1>Логистическое Отображение</h1>
                <b-form>
                    <div class="form-group row" id="modalrowsize">
                        <div class="form-group col-md-6">
                            <label for="r">Значение r в диапазоне (0;4)</label>
                            <b-form-input type="number" size="sx-2" id="r" min="0" max="4"></b-form-input>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="lameria">Построить с лестницей Ламерея?</label>
                            <b-form-checkbox id="lameria"></b-form-checkbox>
                        </div>
                    </div>
                </b-form>
            </b-col>
            <b-col>               
            </b-col>
        </b-row>
      <canvas id="myChart" width="628" height="400"></canvas>
    </b-container>
</template>
