cd %~dp0%
pause
git add .
git add .
git commit -m "app website update"
git subtree push --prefix Web origin gh-pages
pause