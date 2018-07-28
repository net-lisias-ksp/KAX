#!/usr/bin/env bash

source ./CONFIG.inc

FILE=$PACKAGE-$VERSION.zip
echo $FILE
rm $FILE
zip -r $FILE ./GameData/* -x ".*"
zip -r $FILE ./PluginData/* -x ".*"
zip -d $FILE __MACOSX .DS_Store
if [[ -f ./Archive ]] ; then
	rm ./Archive 
fi
if [[ ! -d ./Archive ]] ; then
	mkdir ./Archive
fi
mv $FILE ./Archive
