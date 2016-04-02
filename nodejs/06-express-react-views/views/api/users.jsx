var React = require("react");

var ApiUsers = React.createClass({
    render: function(){
        // {` `}    -> escaping special characters, such as {}
        return <div>{`{name: "Tulis", isValid: true, group: "Admin"}`}</div>;
    }
});

module.exports = ApiUsers;
