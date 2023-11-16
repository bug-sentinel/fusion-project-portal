import { Button, Icon } from '@equinor/eds-core-react';
import { arrow_drop_right } from '@equinor/eds-icons';
import { useFrameworkContext } from '@equinor/portal-core';
import { StyledViewSelectorWrapper } from './ViewPage.Styles';
import { View } from '@portal/types';

type ViewSelectorProps = {
	views: View[];
	currentView: View;
	setViewId: (viewId: string | undefined) => void;
};

export const ViewSelector = ({ views, currentView, setViewId }: ViewSelectorProps) => {
	const contextProvider = useFrameworkContext();

	return (
		<StyledViewSelectorWrapper>
			{views
				.filter((view) => view.key !== currentView.key)
				.map((view) => {
					return (
						<Button
							key={view.key}
							variant="ghost"
							onClick={() => {
								setViewId(view.key);
								contextProvider.clearCurrentContext();
							}}
						>
							{view.name} <Icon {...arrow_drop_right} />
						</Button>
					);
				})}
		</StyledViewSelectorWrapper>
	);
};
