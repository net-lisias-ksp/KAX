#!/usr/bin/env bash

source ./CONFIG.inc

deploy() {
	local DLL=$1

	if [ -f "./$PROJECTSDIR/bin/Release/$DLL.dll" ] ; then
		cp "./$PROJECTSDIR/bin/Release/$DLL.dll" "./GameData/$TARGETDIR/"
		if [ -f "${KSP_DEV}/GameData/$TARGETDIR/" ] ; then
			cp "./$PROJECTSDIR/bin/Release/$DLL.dll" "${KSP_DEV/}GameData/$TARGETDIR/"
		fi

	fi
	if [ -f "./$PROJECTSDIR/bin/Debug/$DLL.dll" ] ; then
		if [ -f "${KSP_DEV}/GameData/$TARGETDIR/" ] ; then
			cp "./$PROJECTSDIR/bin/Debug/$DLL.dll" "${KSP_DEV}/GameData/$TARGETDIR/"
		fi
	fi
}

VERSIONFILE=$PACKAGE.version

cp $VERSIONFILE "./GameData/$TARGETDIR"
deploy $PACKAGE
