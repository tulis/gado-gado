module.exports = function logger(){

    function log(message){
        console.log(message);
    }

    return {
        log: log
    }
};
