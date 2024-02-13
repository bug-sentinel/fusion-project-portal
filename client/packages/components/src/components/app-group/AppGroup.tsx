import { FusionAppGroup } from '@portal/types';
import { useParams } from 'react-router-dom';

import { AppManifest, ListCard } from '@portal/components';

import { css } from '@emotion/css';
import { tokens } from '@equinor/eds-tokens';
import styled from 'styled-components';
import { Typography } from '@equinor/eds-core-react';

export const Styles = {
	Title: styled(Typography)<{ isActive: boolean }>`
		font-weight: ${({ isActive }) => (isActive ? 700 : 500)};
		padding-bottom: ${tokens.spacings.comfortable.medium};
	`,
	groupWrapper: css`
		display: flex;
		flex-direction: column;
		-webkit-flex-direction: column;
		-ms-flex-direction: column;
		width: inherit;
	`,
	groupName: (isActive: boolean) => css`
		font-weight: ${isActive ? 700 : 500};
		line-height: 16px;
		margin: 0;
		height: 24px;
		font-size: 14px;
		margin-bottom: 1rem;
		color: ${tokens.colors.text.static_icons__default.hex};
		margin-block-start: 0;
		margin-block-end: 1rem;
	`,
	Nav: styled.nav`
		display: flex;
		flex-direction: column;
		width: inherit;
	`,
	Group: styled.div`
		display: flex;
		gap: 0.5em;
		min-width: 300px;
		width: 100%;
		align-items: flex-start;
		break-inside: avoid;
		margin-bottom: 2rem;
	`,
	List: styled.ol`
		display: flex;
		flex-direction: column;
		list-style-type: none;
		margin-block-start: 0;
		margin-block-end: 0;
		margin-inline-start: 0px;
		margin-inline-end: 0px;
		padding-inline-start: 0;
		/* gap: 1rem; */
	`,
};

type AppGroupProps = {
	group: FusionAppGroup;
	onFavorite: (key: Partial<AppManifest>) => void;
	dark?: boolean;
};

export const AppGroup = ({ group, onFavorite, dark }: AppGroupProps) => {
	const { appKey } = useParams();
	const isGroupActive = !!group.apps.find((a) => a.key === appKey);

	return (
		<Styles.Group id={`groupe-${group.name}`}>
			<Styles.Nav>
				<Styles.Title isActive={isGroupActive} id={`groupe-${group.name}-name`} title={group.name}>
					{group.name}
				</Styles.Title>
				<Styles.List>
					{group.apps.map((app) => (
						<ListCard
							key={app.key}
							app={app}
							pinButton
							dark={dark}
							onClick={(a) => {
								console.log(a);
							}}
							onFavorite={onFavorite}
						/>
					))}
				</Styles.List>
			</Styles.Nav>
		</Styles.Group>
	);
};
