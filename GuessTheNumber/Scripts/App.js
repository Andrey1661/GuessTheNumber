var app = new Vue({
    el: "#app",
    data: {
        hiddenNumber: null,
        mask: "XXXX",
        success: false,
        answer: null,
        gameStarted: false,
        attemptsCount: 0,
        error: null
    },

    methods: {
        newGame() {
            this.error = null;
            this.answer = null;
            this.success = false;
            this.attemptsCount = 0;

            api.get('new').then(response => {
                var data = response.data;
                this.mask = data.Mask;
                this.hiddenNumber = data.HiddenNumber;
                this.gameStarted = true;
            });
        },
        postAnswer() {
            this.error = null;

            api.post('postanswer',
                {
                    HiddenNumber: this.hiddenNumber,
                    Value: this.answer,
                    AttemptsCount: this.attemptsCount
                }).then(response => {

                var data = response.data;
                this.mask = data.Mask;
                this.hiddenNumber = data.HiddenNumber;
                this.attemptsCount = data.AttemptsCount;
                this.success = data.Success;
                this.answer = null;

            }).catch(error => {
                var data = error.response.data;

                if (data != null && data.ModelState !== undefined) {
                    this.error = data.ModelState["model.Answer"][0];
                }

                this.error = "Возникла непредвиденная ошибка";
            });
        }
    }
})