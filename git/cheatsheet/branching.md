# Branching

* Let's say we want to create new branch, called issue-01, from command line

        $ git checkout -b issue-01

* Commit changes (assuming on README.md)

        $ git add README.md
        $ git commit -m "Fix typo on README.md"

* Push commit to remote repo and we will get fatal message saying that the remote repo does not have issue-01 branch set-up

        $ git push
        fatal: The current branch issue-01 has no upstream branch.
        To push the current branch and set the remote as upstream, use

        git push --set-upstream origin issue-01

* Copy and run the command above to set up upstream branch

        $ git push --set-upstream origin issue-01
        Enumerating objects: 1, done.
        Counting objects: 100% (1/1), done.
        Writing objects: 100% (1/1), 286 bytes | 143.00 KiB/s, done.
        Total 1 (delta 0), reused 0 (delta 0)
        remote:
        remote: Create a pull request for 'issue-01' on GitHub by visiting:
        remote:      https://github.com/tulis/repo1/pull/new/issue-01
        remote:
        To https://github.com/tulis/repo1.git
        * [new branch]      issue-01 -> issue-01
        Branch 'issue-01' set up to track remote branch 'issue-01' from 'origin'.

* Merge from branch to master using fast-forward, **`--ff-only`**, to have clean linear history

        $ git checkout master
        $ git merge --ff-only issue-01

* After merging, it is good to delete branch locally and remotely to reduce pollution. From following commands, `origin` is refering to remote name.

        # Remove upstream branch
        $ git push --delete origin issue-01
        # Remove local branch
        $ git branch -d issue-01

# References
* https://stackoverflow.com/questions/2003505/how-do-i-delete-a-git-branch-both-locally-and-remotely