# Pushing code to two remotes

Let's say we have 2 repos:
1. https://github.com/tulis/repo1.git
2. https://github.com/tulis/repo2.git

Steps:
* Clone from either repo to local repo

        $ git clone https://github.com/tulis/repo1.git

* If we list all remote urls in local rep, we will only have 1 **Fetch URL**.

        $ git remote show origin

        * remote origin
        Fetch URL: https://github.com/tulis/repo1.git        
        HEAD branch: master
        Remote branch:
            master tracked
        Local branch configured for 'git pull':
            master merges with remote master
        Local ref configured for 'git push':
            master pushes to master (up to date)

* In order to push code into 2 repos at the same time, we need to add **PUSH remote URL**.

        $ git remote set-url --add --push origin https://github.com/tulis/repo1.git
        $ git remote set-url --add --push origin https://github.com/tulis/repo2.git

* List remote urls again, 2 PUSH URLs are added.

        $ git remote show origin

        * remote origin
        Fetch URL: https://github.com/tulis/repo1.git
        Push  URL: https://github.com/tulis/repo1.git
        Push  URL: https://github.com/tulis/repo2.git
        HEAD branch: master
        Remote branch:
            master tracked
        Local branch configured for 'git pull':
            master merges with remote master
        Local ref configured for 'git push':
            master pushes to master (up to date)

* When pushing code, you will be prompted to input your username and password twice. To minimize the frequency of being asked again, we can cache git credential. 
    * Linux

        By default, Git will cache credential under Linux platform for 15 minutes.

            $ git config --global credential.helper cache
            # Set git to use the credential memory cache


        To change the default password cache timeout, enter the following:

            $ git config --global credential.helper 'cache --timeout=3600'
            # Set the cache to timeout after 1 hour (setting is in seconds)

    * Windows

            $ git config --global credential.helper wincred


# References
* https://stackoverflow.com/questions/14290113/git-pushing-code-to-two-remotes
* https://web.archive.org/web/20190326122951/https://stackoverflow.com/questions/14290113/git-pushing-code-to-two-remotes
* https://help.github.com/en/articles/caching-your-github-password-in-git