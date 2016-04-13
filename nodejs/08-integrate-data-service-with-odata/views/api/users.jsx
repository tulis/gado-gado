var React = require("react");

var ApiUsers = React.createClass({
    render: function(){
        return <div>
            <pre>
                { JSON.stringify(this.props, null, 2) }
            </pre>
        </div>;
    }
});

module.exports = ApiUsers;
