
function func2(param1) {
    throw "param1 is undefined";
}

function func1(param1) {
    func2(param1);
}

var app = new Vue({
    el: '#app',
    data: {
        message: 'Hello World',
        getInput2: '12',
        getInput3: '2',
        postInput1: 'Hello World',
        getResult1: '',
        getResult2: '',
        getResult3: '',
        postResult1: ''
    },
    methods: {
        getMethod1: function (event) {
            let that = this;
            axios.get('/api/frontvalues')
                .then(function (response) {
                    that.getResult1 = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {

                });
        },
        getMethod2: function (event) {
            let that = this;
            axios.get('/api/frontdelay/' + this.getInput2)
                .then(function (response) {
                    that.getResult2 = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {

                });
        },
        getMethod3: function (event) {
            let that = this;
            axios.get('/api/frontdb/' + this.getInput3)
                .then(function (response) {
                    that.getResult3 = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {

                });
        },
        postMethod2: function (event) {
            let that = this;
            axios.post('/api/frontvalues', '"' + this.postInput1 + '"', {
                    headers: { 'Content-Type': 'application/json'}
                })
                .then(function (response) {
                    that.postResult1 = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {

                });
        },
        exceptionDemo: function (event) {
            func1();
        }
    }
});