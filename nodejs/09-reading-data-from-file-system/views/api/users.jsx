(function(){
    var React = require("react");
    var Lazy = require("lazy.js");
    var ApiUsers = React.createClass({
        render: function renderApiUsers(){
            var users = Lazy(this.props)
                .pick(["value"])
                .value()["value"];

            return <div>
                <pre>
                    { JSON.stringify(users, null, 2) }
                </pre>
            </div>;
        }
    });

    module.exports = ApiUsers;
})(module);
